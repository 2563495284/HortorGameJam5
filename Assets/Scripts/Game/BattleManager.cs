using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    Battle _battleData;
    public Battle battleData
    {
        get
        {
            return battleData;
        }
    }
    public List<RoundSettlement> roundSettlements;
    public RoundSettlement currentRoundSettlement;
    public int round;
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
    public void SetBattleManager(Battle data)
    {
        _battleData = data;
    }
    public void InitGame()
    {
        round = 0;
        roundSettlements = battleData.roundSettlements;
    }
    public void StartRound()
    {
        currentRoundSettlement = roundSettlements[round];
    }
    public void nextRound()
    {

    }
}
