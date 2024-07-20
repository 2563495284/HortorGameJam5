using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class BattleSystem : MonoBehaviour
{
    // public RoleCard playerCard;
    // public RoleCard enemyCard;

    public Text dialogueText;
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private EBattleState state;

    public GameObject skill;
    public Material dissolveMaterial;

    public GameObject battleFinish;

    public Button btnBattleFinish;
    public BattleHeroInfo playerBattleInfo
    {
        get
        {
            return BattleManager.Instance.playerBattleHeroInfo;
        }
    }
    public BattleHeroInfo enemyBattleInfo
    {
        get
        {
            return BattleManager.Instance.enemyBattleHeroInfo;
        }
    }
    void Start()
    {
        skill.SetActive(false);
        state = EBattleState.START;
        btnBattleFinish.onClick.AddListener(OnClickBtnBattleFinish);

        battleFinish.SetActive(false);
        StartBattle();
    }
    void OnDestroy()
    {

    }
    private void OnClickBtnBattleFinish()
    {
        SceneSwitcher.LoadSceneByIndex(ESceneType.MAINSCENE);
    }
    private SBattleData battleData;
    async void StartBattle()
    {
        BattleManager.Instance.InitGame();
        initHero();
        await UniTask.Delay(2000);
        dialogueText.text = "回合开始！";
        nextRound();
    }
    async void nextRound()
    {
        battleData = BattleManager.Instance.getNextRoundState();
        Debug.LogWarning("<<<<getNextRoundState<<<<" + battleData);
        switch (battleData.battleState)
        {
            case EBattleState.PLAYERTURN:
                await PlayerTurnAsync();
                break;
            case EBattleState.ENEMYTURN:
                await EnemyTurnAsync();
                break;
            case EBattleState.WON:
                WonTurn();
                break;
            case EBattleState.LOST:
                LostTurn();
                break;
        }
    }

    public async UniTask PlayerTurnAsync()
    {
        await UseSkill(battleData.skillHeroName, battleData.textTargetHolder, battleData.skill, EBattleHeroType.PLAYER);
        CheckHeroStateChange();
        await showHeroStateChange();
        nextRound();
    }

    public async UniTask EnemyTurnAsync()
    {
        await UseSkill(battleData.skillHeroName, battleData.textTargetHolder, battleData.skill, EBattleHeroType.ENEMY);
        CheckHeroStateChange();
        await showHeroStateChange();
        nextRound();
    }
    public void WonTurn()
    {
        dialogueText.text = "我方胜利！";
        battleFinish.SetActive(true);
    }
    public void LostTurn()
    {
        dialogueText.text = "敌人胜利！";
        battleFinish.SetActive(true);
    }
    void EndBattle()
    {
        if (state == EBattleState.WON)
        {
            dialogueText.text = "You won the battle!";
        }
        else if (state == EBattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
        }
    }
    public void initHero()
    {
        playerHUD.init(EBattleHeroType.PLAYER);
        enemyHUD.init(EBattleHeroType.ENEMY);
    }
    public void CheckHeroStateChange()
    {
        playerHUD.CheckHeroStateChange(playerBattleInfo.roundState);
        enemyHUD.CheckHeroStateChange(enemyBattleInfo.roundState);
    }
    public async UniTask showHeroStateChange()
    {
        dialogueText.text = "假装在状态同步";
        await playerHUD.playHeroStateChange();
        await enemyHUD.playHeroStateChange();
        await UniTask.Delay(500);
    }
    #region  使用技能
    private float _skillTweenHandle;
    public async UniTask UseSkill(string textPlayer, string textTargetHolder, Skill curtSkill, EBattleHeroType battleHeroType)
    {
        var round = $"回合 {battleData.round}";
        var uiDelayMs = 800;
        if (curtSkill == null)
        {
            dialogueText.text = $"{round} {textPlayer}说 : 我魔法值不足";
            Debug.Log(dialogueText.text);
            await UniTask.Delay(uiDelayMs);
            return;
        }
        switch (battleHeroType)
        {
            case EBattleHeroType.PLAYER:
                dialogueText.text = $"{round} {curtSkill.text.Replace("%s", textTargetHolder)}";
                dissolveMaterial.SetColor("_EdgeColor", new Color(0, 0.1f, 1, 1));
                break;
            case EBattleHeroType.ENEMY:
                dialogueText.text = $"{round} {curtSkill.text.Replace("%s", textTargetHolder)}";
                dissolveMaterial.SetColor("_EdgeColor", new Color(1, 0.1f, 0, 1));
                break;
        }
        SkillRender skillRender = skill.GetComponent<SkillRender>();
        if (skillRender != null)
        {
            skillRender.OnData(curtSkill, onClickSkill);
        }
        await PlayCardMove(battleHeroType);
        await UniTask.Delay(uiDelayMs);
        await PlayCardDissolve();
        _skillTweenHandle = 0f;

    }
    private UniTask PlayCardDissolve()
    {
        _skillTweenHandle = 0f;
        var tcs = new UniTaskCompletionSource();
        DOTween.To(
            () => _skillTweenHandle,
            (t) =>
            {
                dissolveMaterial.SetFloat("_TimeDuration", -2.3f * t + 1.3f);
            },
            1f,
            1f
            ).OnComplete(() =>
            {
                skill.SetActive(false);
                tcs.TrySetResult();
            });
        return tcs.Task;
    }
    private UniTask PlayCardMove(EBattleHeroType battleHeroType)
    {
        float originalY = 0;
        float originalX = Screen.width;
        float offsetH = 300f;
        switch (battleHeroType)
        {
            case EBattleHeroType.PLAYER:
                originalY = 0;
                originalX = Screen.width;
                skill.transform.position.Set(originalX, originalY, 0f);
                offsetH = 400f;
                break;
            case EBattleHeroType.ENEMY:
                originalY = 0;
                originalX = -Screen.width;
                skill.transform.position.Set(originalX, originalY, 0f);
                offsetH = 400f;
                break;
        }

        dissolveMaterial.SetFloat("_TimeDuration", 1.3f);
        skill.SetActive(true);
        Vector2 startPos = skill.transform.TransformPoint(new Vector2(originalX, originalY));
        Vector2 midPos = skill.transform.TransformPoint(new Vector2(originalX / 2, originalY + offsetH));
        Vector2 endPos = skill.transform.TransformPoint(new Vector2(0f, 0f));
        List<Vector2> cp = new List<Vector2>
        {
            startPos,
            midPos,
            midPos,
            endPos
        };
        _skillTweenHandle = 0f;
        var tcs = new UniTaskCompletionSource();
        DOTween.To(
            () => _skillTweenHandle,
            (t) =>
            {
                Vector2 pos = PointOnCubicBezier(cp, t);
                skill.transform.position = new Vector3(pos.x, pos.y, 0f);
            },
            1f,
            1f
            ).OnComplete(() => tcs.TrySetResult());
        return tcs.Task;
    }
    public Vector2 PointOnCubicBezier(List<Vector2> cp, float t)
    {
        float ax, bx, cx;
        float ay, by, cy;
        float tSquared, tCubed;
        Vector2 result = new Vector2(0f, 0f);

        cx = 3.0f * (cp[1].x - cp[0].x);
        bx = 3.0f * (cp[2].x - cp[1].x) - cx;
        ax = cp[3].x - cp[0].x - cx - bx;

        cy = 3.0f * (cp[1].y - cp[0].y);
        by = 3.0f * (cp[2].y - cp[1].y) - cy;
        ay = cp[3].y - cp[0].y - cy - by;

        tSquared = t * t;
        tCubed = tSquared * t;

        result.x = (ax * tCubed) + (bx * tSquared) + (cx * t) + cp[0].x;
        result.y = (ay * tCubed) + (by * tSquared) + (cy * t) + cp[0].y;

        return result;
    }
    #endregion
    private void onClickSkill(Skill skill)
    {
        SkillInfoView.Instance.ShowSkillInfoView(skill);
    }
}