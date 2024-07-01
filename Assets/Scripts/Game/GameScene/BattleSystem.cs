using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Card;
public class BattleSystem : MonoBehaviour
{

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public RoleCard playerCard;
    public RoleCard enemyCard;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private EBattleState state;

    void Start()
    {
        state = EBattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {

        dialogueText.text = "A wild " + enemyCard.cardName+ " approaches...";

        playerHUD.SetHUD(playerCard);
        enemyHUD.SetHUD(enemyCard);

        yield return new WaitForSeconds(2f);

        state = EBattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
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
}
