using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class GDBattlefield: DataBase {
    [Preserve]
    public GDBattlefield() {
    }
    
    /// <summary>
    /// 房间id
    /// <summary>
    public string id = string.Empty;
    /// <summary>
    /// 服务器id
    /// <summary>
    public string sid = string.Empty;
    /// <summary>
    /// 战场名
    /// <summary>
    public string name = string.Empty;
    /// <summary>
    /// 战场状态
    /// <summary>
    public EMBattlefieldState state = EMBattlefieldState.init;
    /// <summary>
    /// 自由模式成员列表
    /// <summary>
    public Dictionary<long, GDBattlefieldRole> roles = new Dictionary<long, GDBattlefieldRole>();
    /// <summary>
    /// 创建时间
    /// <summary>
    public long createAt = 0;
}