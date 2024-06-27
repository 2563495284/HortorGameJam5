using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class GDBanInfo: DataBase {
    [Preserve]
    public GDBanInfo() {
    }
    
    /// <summary>
    /// 封禁原因
    /// <summary>
    public string reason = string.Empty;
    /// <summary>
    /// 封禁解除时间
    /// <summary>
    public long endTime = 0;
}