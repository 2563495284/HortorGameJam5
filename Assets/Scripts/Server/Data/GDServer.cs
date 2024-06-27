using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class GDServer: DataBase {
    [Preserve]
    public GDServer() {
    }
    
    /// <summary>
    /// 服务器id
    /// <summary>
    public long id = 0;
    /// <summary>
    /// 服务器名
    /// <summary>
    public string name = string.Empty;
    /// <summary>
    /// 服务器状态
    /// <summary>
    public EMServerStatus status = EMServerStatus.closed;
    /// <summary>
    /// 服务器繁忙状态
    /// <summary>
    public EMServerBusyStatus busyStatus = EMServerBusyStatus.normal;
}