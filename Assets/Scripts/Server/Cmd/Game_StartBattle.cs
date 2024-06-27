using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 战斗开始
/// <summary>
public partial class Game_StartBattle: ReqBase {
    public Game_StartBattle() {
    }
    
    public long roleId1;
    /// <summary>
    /// 玩家 1 id
    /// <summary>
    public long player1;
    public long roleId2;
    /// <summary>
    /// 玩家 2 id
    /// <summary>
    public long player2;
}