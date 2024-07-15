using System.Collections;
using System.Collections.Generic;
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

    public GameObject Skill;
    public Material dissolveMaterial;
    void Start()
    {
        state = EBattleState.START;
        StartBattle();
    }
    private SBattleData battleData;
    async void StartBattle()
    {
        BattleManager.Instance.InitGame();
        this.refreshHeroState();
        await UniTask.Delay(2000);
        dialogueText.text = "回合开始！";
        nextRound();
    }
    void nextRound()
    {
        battleData = BattleManager.Instance.getNextRoundState();
        switch (battleData.battleState)
        {
            case EBattleState.PLAYERTURN:
                PlayerTurn();
                break;
            case EBattleState.ENEMYTURN:
                EnemyTurn();
                break;
            case EBattleState.WON:
                WonTurn();
                break;
            case EBattleState.LOST:
                LostTurn();
                break;
        }
    }

    async void PlayerTurn()
    {
        dialogueText.text = $"我方回合 : UseSkill {battleData.skill.name}";
        refreshHeroState();
        await UseSkill(battleData.skill);
        showHeroStateChange();
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

    async void EnemyTurn()
    {
        dialogueText.text = $"敌方回合 : UseSkill {battleData.skill.name}";
        refreshHeroState();
        await UseSkill(battleData.skill);
        showHeroStateChange();
        nextRound();
    }
    async void WonTurn()
    {

    }
    async void LostTurn()
    {

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

    public void OnAttackButton()
    {
        if (state != EBattleState.PLAYERTURN)
            return;

        //StartCoroutine(PlayerAttack());
    }
    public void refreshHeroState()
    {
        playerHUD.refreshHeroState(BattleManager.Instance.playerBattleHeroInfo.battleHero);
        playerHUD.refreshHeroState(BattleManager.Instance.enemyBattleHeroInfo.battleHero);
    }
    public async UniTask showHeroStateChange()
    {
        dialogueText.text = "假装在状态同步";
        await UniTask.Delay(1000);
    }
    #region  使用技能
    private float _skillTweenHandle;
    public async UniTask UseSkill(Skill curtSkill)
    {
        float originalY = 0;
        float originalX = Screen.width;
        Skill.transform.position.Set(originalX, originalY, 0f);

        dissolveMaterial.SetFloat("_TimeDuration", 1.3f);
        Skill.SetActive(true);
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
                Skill.SetActive(false);
                tcs.TrySetResult();
            });
        return tcs.Task;
    }
    private UniTask PlayCardMove()
    {
        float originalY = 0;
        float originalX = Screen.width;
        Vector2 startPos = Skill.transform.TransformPoint(new Vector2(originalX, originalY));
        Vector2 midPos = Skill.transform.TransformPoint(new Vector2(originalX / 2, originalY + 300f));
        Vector2 endPos = Skill.transform.TransformPoint(new Vector2(0f, 0f));
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
                Skill.transform.position = new Vector3(pos.x, pos.y, 0f);
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