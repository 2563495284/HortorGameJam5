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
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        // playerHUD.SetHUD(playerCard);
        // enemyHUD.SetHUD(enemyCard);

        yield return new WaitForSeconds(2f);

        state = EBattleState.PLAYERTURN;
        PlayerTurn();
    }

    async void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
        await UseSkill(null);
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

    //IEnumerator EnemyTurn()
    //{
    //    dialogueText.text = enemyUnit.unitName + " attacks!";

    //    yield return new WaitForSeconds(1f);

    //    bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

    //    playerHUD.SetHP(playerUnit.currentHP);

    //    yield return new WaitForSeconds(1f);

    //    if (isDead)
    //    {
    //        state = EBattleState.LOST;
    //        EndBattle();
    //    }
    //    else
    //    {
    //        state = EBattleState.PLAYERTURN;
    //        PlayerTurn();
    //    }
    //}

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
}