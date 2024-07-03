using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 战斗
/// <summary>
public partial class Battle: DataBase {
    [Preserve]
    public Battle() {
    }
    
    public long id = 0;
    /// <summary>
    /// 玩家 1
    /// <summary>
    public Hero player1 = new Hero();
    /// <summary>
    /// 玩家 2
    /// <summary>
    public Hero player2 = new Hero();
    /// <summary>
    /// 战斗状态 1
    /// <summary>
    public BattleHero battlePlayer1 = new BattleHero();
    /// <summary>
    /// 战斗状态 2
    /// <summary>
    public BattleHero battlePlayer2 = new BattleHero();
    /// <summary>
    /// 单签回合
    /// <summary>
    public long round = 0;
    /// <summary>
    /// 每回合战斗结算
    /// <summary>
    public List<RoundSettlement> roundSettlements = new List<RoundSettlement>();
    /// <summary>
    /// 战斗是否结束
    /// <summary>
    public bool finished = false;
    /// <summary>
    /// 胜者
    /// <summary>
    public string winner = string.Empty;
}