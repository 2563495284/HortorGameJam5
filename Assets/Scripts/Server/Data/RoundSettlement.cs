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
    
    public long round = 0;
    public BattleHero attacker = new BattleHero();
    public BattleHero defender = new BattleHero();
    public long damage = 0;
    public List<string> effects = new List<string>();
}