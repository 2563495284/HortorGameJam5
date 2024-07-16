using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EBattleHeroType
{
    PLAYER,
    ENEMY
}
public struct SBattleData
{
    public EBattleState battleState;
    public Skill skill;

}
public class BattleHeroInfo
{
    private EBattleHeroType _battleHeroType;
    public EBattleHeroType battleHeroType
    {
        get
        {
            return _battleHeroType;
        }
    }
    public BattleHeroInfo(EBattleHeroType eBattleHeroType)
    {
        _battleHeroType = eBattleHeroType;
    }
    private BattleHero _battleHero;
    public BattleHero battleHero
    {
        get
        {
            return _battleHero;
        }
        set
        {
            _battleHero = value;
        }
    }

    private Hero _hero;
    public Hero hero
    {
        get
        {
            return _hero;
        }
        set
        {
            _hero = value;
        }
    }
    private RoundState _roundState;
    public RoundState roundState
    {
        get
        {
            return _roundState;
        }
        set
        {
            _roundState = value;
        }
    }

}
public class BattleManager : Singleton<BattleManager>
{
    public Battle battle;
    public RoundSettlement currentRoundSettlement;
    public BattleHeroInfo playerBattleHeroInfo = new BattleHeroInfo(EBattleHeroType.PLAYER);

    public BattleHeroInfo enemyBattleHeroInfo = new BattleHeroInfo(EBattleHeroType.ENEMY);

    public int round;
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
    public void SetBattleManager(Battle data)
    {
        battle = data;
    }
    public void InitGame()
    {
        round = 0;
        initHerosState();

    }
    public SBattleData getNextRoundState()
    {
        SBattleData battleData = new SBattleData();
        Skill skill;
        if (round >= battle.roundSettlements.Count)
        {
            if (battle.winnerHero == playerBattleHeroInfo.hero.id)
            {
                battleData.battleState = EBattleState.WON;
            }
            else
            {
                battleData.battleState = EBattleState.LOST;
            }
            return battleData;
        }
        currentRoundSettlement = battle.roundSettlements[round];
        if (currentRoundSettlement.attacker.id == playerBattleHeroInfo.battleHero.id)
        {
            battleData.battleState = EBattleState.PLAYERTURN;
            skill = playerBattleHeroInfo.hero.skills.Find(x => x.id == currentRoundSettlement.skill);
            playerBattleHeroInfo.battleHero = currentRoundSettlement.attacker;
            playerBattleHeroInfo.roundState = currentRoundSettlement.attackerRoundStates;

            enemyBattleHeroInfo.battleHero = currentRoundSettlement.defender;
            enemyBattleHeroInfo.roundState = currentRoundSettlement.defenderRoundStates;
        }
        else
        {
            battleData.battleState = EBattleState.ENEMYTURN;
            skill = enemyBattleHeroInfo.hero.skills.Find(x => x.id == currentRoundSettlement.skill);
            playerBattleHeroInfo.battleHero = currentRoundSettlement.defender;
            playerBattleHeroInfo.roundState = currentRoundSettlement.defenderRoundStates;

            enemyBattleHeroInfo.battleHero = currentRoundSettlement.attacker;
            enemyBattleHeroInfo.roundState = currentRoundSettlement.attackerRoundStates;
        }
        round++;
        battleData.skill = skill;
        return battleData;
    }
    public void initHerosState()
    {

        if (PlayerModel.Instance.curtHero.id == battle.player1.id)
        {
            playerBattleHeroInfo.hero = battle.player1;
            enemyBattleHeroInfo.hero = battle.player2;
            playerBattleHeroInfo.battleHero = battle.battlePlayer1;
            enemyBattleHeroInfo.battleHero = battle.battlePlayer2;
        }
        else
        {
            playerBattleHeroInfo.hero = battle.player2;
            enemyBattleHeroInfo.hero = battle.player1;
            playerBattleHeroInfo.battleHero = battle.battlePlayer2;
            enemyBattleHeroInfo.battleHero = battle.battlePlayer1;
        }
    }
}
