using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 回合结算响应
/// <summary>
public partial class RoundSettlementResp: DataBase {
    [Preserve]
    public RoundSettlementResp() {
    }
    
    /// <summary>
    /// 所属回合
    /// <summary>
    public long round = 0;
    /// <summary>
    /// 当前回合的技能
    /// <summary>
    public long skill = 0;
    /// <summary>
    /// 己方英雄状态
    /// <summary>
    public BattleFinishHeroResp attacker = new BattleFinishHeroResp();
    /// <summary>
    /// 敌方英雄状态
    /// <summary>
    public BattleFinishHeroResp defender = new BattleFinishHeroResp();
    /// <summary>
    /// 攻击者的状态变化
    /// <summary>
    public RoundState attackerRoundStates = new RoundState();
    /// <summary>
    /// 防御者的状态变化
    /// <summary>
    public RoundState defenderRoundStates = new RoundState();
}