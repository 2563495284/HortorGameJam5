using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEditor;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.Rendering;
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

    public Text skillText;
    public Material dissolveMaterial;
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
        state = EBattleState.START;
        StartBattle();
    }
    private SBattleData battleData;
    async void StartBattle()
    {
        BattleManager.Instance.InitGame();
        initHero();
        refreshHeroState();
        await UniTask.Delay(2000);
        dialogueText.text = "回合开始！";
        nextRound();
    }
    async void nextRound()
    {
        battleData = BattleManager.Instance.getNextRoundState();
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
        dialogueText.text = $"我方回合 : UseSkill {battleData.skill.name}";
        await UseSkill(battleData.skill);
        await showHeroStateChange();
        refreshHeroState();
        nextRound();
    }

    //IEnumerator PlayerAttack()
    //{
    //    bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

    //    enemyHUD.SetHP(enemyUnit.currentHP);
    //    dialogueText.text = "The attack is successful!";

    //    yield return new WaitForSeconds(2f);

    //    if (isDead)
    //    {
    //        state = EBattleState.WON;
    //        EndBattle();
    //    }
    //    else
    //    {
    //        state = EBattleState.ENEMYTURN;
    //        StartCoroutine(EnemyTurn());
    //    }
    //}

    public async UniTask EnemyTurnAsync()
    {
        dialogueText.text = $"敌方回合 : UseSkill {battleData.skill.name}";
        await UseSkill(battleData.skill);
        await showHeroStateChange();
        refreshHeroState();
        nextRound();
    }
    public void WonTurn()
    {
        dialogueText.text = "我方胜利！";
    }
    public void LostTurn()
    {
        dialogueText.text = "敌人胜利！";
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
        playerHUD.init(playerBattleInfo.hero);
        enemyHUD.init(enemyBattleInfo.hero);
    }
    public void refreshHeroState()
    {
        playerHUD.refreshHeroState(playerBattleInfo.battleHero);
        enemyHUD.refreshHeroState(enemyBattleInfo.battleHero);
    }
    public async UniTask showHeroStateChange()
    {
        dialogueText.text = "假装在状态同步";
        await playerHUD.playHeroStateChange(playerBattleInfo.roundState);
        await enemyHUD.playHeroStateChange(enemyBattleInfo.roundState);
        await UniTask.Delay(500);
    }
    #region  使用技能
    private float _skillTweenHandle;
    public async UniTask UseSkill(Skill curtSkill)
    {
        skillText.text = curtSkill.name;

        float originalY = 0;
        float originalX = Screen.width;
        skill.transform.position.Set(originalX, originalY, 0f);

        dissolveMaterial.SetFloat("_TimeDuration", 1.3f);
        skill.SetActive(true);
        await PlayCardMove();
        await UniTask.Delay(800);
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
    private UniTask PlayCardMove()
    {
        float originalY = 0;
        float originalX = Screen.width;
        Vector2 startPos = skill.transform.TransformPoint(new Vector2(originalX, originalY));
        Vector2 midPos = skill.transform.TransformPoint(new Vector2(originalX / 2, originalY + 300f));
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
}