using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EBattleHeroType
{
    PLAYER,
    ENEMY
}

public struct SBattleData
{
    public EBattleState battleState;
    public int round;
    public Skill skill;
    public string skillHeroName;
    public string textTargetHolder;
}

public class BattleHeroInfo
{
    private EBattleHeroType _battleHeroType;

    public EBattleHeroType battleHeroType
    {
        get { return _battleHeroType; }
    }

    public BattleHeroInfo(EBattleHeroType eBattleHeroType)
    {
        _battleHeroType = eBattleHeroType;
    }

    public void init(BattleFinishHeroResp hero)
    {
        _hero = hero;
        maxHp = hero.hp;
        hp = hero.hp;
        maxMp = hero.mp;
        mp = hero.mp;
        heroName = hero.name;
        heroId = hero.id;
    }

    public string heroName;
    public long heroId;
    public long maxHp;
    public long hp;
    public long maxMp;
    public long mp;
    private BattleFinishHeroResp _hero;

    public BattleFinishHeroResp hero
    {
        get { return _hero; }
    }

    public RoundState roundState;

    public Skill getHeroSkillById(long skillId)
    {
        return _hero.battleSkills.Find(skill => skill.id == skillId);
    }
}

public class BattleManager : Singleton<BattleManager>
{
    public BattleFinishResp battleFinishData;
    public RoundSettlementResp currentRoundSettlement;
    public BattleHeroInfo playerBattleHeroInfo = new BattleHeroInfo(EBattleHeroType.PLAYER);

    public BattleHeroInfo enemyBattleHeroInfo = new BattleHeroInfo(EBattleHeroType.ENEMY);

    public int round;

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    public void SetBattleManager(BattleFinishResp data)
    {
        battleFinishData = data;
    }

    public void InitGame()
    {
        round = 1;
        initHerosState();
    }

    public SBattleData getNextRoundState()
    {
        SBattleData battleData = new SBattleData();
        battleData.round = round;
        Skill skill;
        Debug.Log($"{round}, {battleFinishData.roundSettlements.Count()}");
        if (round > battleFinishData.roundSettlements.Count)
        {
            if (battleFinishData.winnerHero == playerBattleHeroInfo.heroId)
            {
                battleData.battleState = EBattleState.WON;
            }
            else
            {
                battleData.battleState = EBattleState.LOST;
            }

            return battleData;
        }

        currentRoundSettlement = battleFinishData.roundSettlements[round-1];
        if (currentRoundSettlement.attackerRoundStates.heroId == playerBattleHeroInfo.heroId)
        {
            battleData.battleState = EBattleState.PLAYERTURN;
            skill = playerBattleHeroInfo.getHeroSkillById(currentRoundSettlement.skill);
            battleData.skillHeroName = playerBattleHeroInfo.heroName;
            battleData.textTargetHolder = enemyBattleHeroInfo.heroName;
            playerBattleHeroInfo.roundState = currentRoundSettlement.attackerRoundStates;
            enemyBattleHeroInfo.roundState = currentRoundSettlement.defenderRoundStates;
        }
        else
        {
            battleData.battleState = EBattleState.ENEMYTURN;
            skill = enemyBattleHeroInfo.getHeroSkillById(currentRoundSettlement.skill);
            battleData.skillHeroName = enemyBattleHeroInfo.heroName;
            battleData.textTargetHolder = playerBattleHeroInfo.heroName;
            playerBattleHeroInfo.roundState = currentRoundSettlement.defenderRoundStates;
            enemyBattleHeroInfo.roundState = currentRoundSettlement.attackerRoundStates;
        }

        round++;

        battleData.skill = skill;
        return battleData;
    }

    public void initHerosState()
    {
        if (battleFinishData.player1.id == PlayerModel.Instance.curtHero.id)
        {
            playerBattleHeroInfo.init(battleFinishData.player1);
            enemyBattleHeroInfo.init(battleFinishData.player2);
        }
        else
        {
            playerBattleHeroInfo.init(battleFinishData.player2);
            enemyBattleHeroInfo.init(battleFinishData.player1);
        }
    }

    public BattleHeroInfo getBattleHeroInfo(EBattleHeroType battleHeroType)
    {
        if (battleHeroType == EBattleHeroType.PLAYER)
        {
            return BattleManager.Instance.playerBattleHeroInfo;
        }
        else
        {
            return BattleManager.Instance.enemyBattleHeroInfo;
        }
    }
}