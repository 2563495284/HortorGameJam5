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
    public BattleHero battlePlayer1 = new BattleHero();
    public BattleHero battlePlayer2 = new BattleHero();
    public long round = 0;
    /// <summary>
    /// 每回合战斗结算
    /// <summary>
    public List<RoundSettlement> roundSettlements = new List<RoundSettlement>();
    public bool finished = false;
    public string winner = string.Empty;
}