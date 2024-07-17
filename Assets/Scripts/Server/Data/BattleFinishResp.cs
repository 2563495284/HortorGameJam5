using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 战斗结算响应
/// <summary>
public partial class BattleFinishResp: DataBase {
    [Preserve]
    public BattleFinishResp() {
    }
    
    public long id = 0;
    /// <summary>
    /// 回合
    /// <summary>
    public long round = 0;
    /// <summary>
    /// 己方英雄状态
    /// <summary>
    public BattleFinishHeroResp attacker = new BattleFinishHeroResp();
    /// <summary>
    /// 敌方英雄状态
    /// <summary>
    public BattleFinishHeroResp defender = new BattleFinishHeroResp();
    /// <summary>
    /// 每回合战斗结算
    /// <summary>
    public List<RoundSettlementResp> roundSettlements = new List<RoundSettlementResp>();
    /// <summary>
    /// 战斗是否结束
    /// <summary>
    public bool finished = false;
    /// <summary>
    /// 胜者
    /// <summary>
    public string winner = string.Empty;
    /// <summary>
    /// 胜利的英雄 id
    /// <summary>
    public long winnerHero = 0;
}