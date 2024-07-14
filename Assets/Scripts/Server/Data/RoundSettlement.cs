using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 回合结算
/// <summary>
public partial class RoundSettlement: DataBase {
    [Preserve]
    public RoundSettlement() {
    }
    
    /// <summary>
    /// 所属回合
    /// <summary>
    public long round = 0;
    /// <summary>
    /// 当前回合的攻击者
    /// <summary>
    public BattleHero attacker = new BattleHero();
    /// <summary>
    /// 当前回合的防御者
    /// <summary>
    public BattleHero defender = new BattleHero();
    /// <summary>
    /// 当前回合的技能
    /// <summary>
    public long skill = 0;
    /// <summary>
    /// 攻击者的状态变化
    /// <summary>
    public RoundState attackerRoundStates = new RoundState();
    /// <summary>
    /// 防御者的状态变化
    /// <summary>
    public RoundState defenderRoundStates = new RoundState();
}