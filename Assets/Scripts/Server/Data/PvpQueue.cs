using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// pvp 匹配
/// <summary>
public partial class PvpQueue: DataBase {
    [Preserve]
    public PvpQueue() {
    }
    
    public long id = 0;
    public long selfRole = 0;
    /// <summary>
    /// 当前玩家的英雄 id
    /// <summary>
    public long selfHero = 0;
    public long roleId1 = 0;
    /// <summary>
    /// 玩家 1
    /// <summary>
    public Hero player1 = new Hero();
    public long roleId2 = 0;
    /// <summary>
    /// 玩家 2
    /// <summary>
    public Hero player2 = new Hero();
    /// <summary>
    /// 入队时间
    /// <summary>
    public long inQueue = 0;
    /// <summary>
    /// 匹配状态:1-入队、2-匹配、3-成功，如果 status=2，此时 battle 不为0，表示对局信息已经创建
    /// <summary>
    public long status = 0;
    /// <summary>
    /// 如果匹配成功，则直接对局 id
    /// <summary>
    public long battleId = 0;
}