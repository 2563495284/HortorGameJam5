using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class GDServerRole: DataBase {
    [Preserve]
    public GDServerRole() {
    }
    
    /// <summary>
    /// 角色id
    /// <summary>
    public long id = 0;
    /// <summary>
    /// 服务器id
    /// <summary>
    public long sId = 0;
    /// <summary>
    /// 角色名
    /// <summary>
    public string name = string.Empty;
    /// <summary>
    /// 角色等级
    /// <summary>
    public int lv = 0;
    /// <summary>
    /// 上次登录时间
    /// <summary>
    public long loginAt = 0;
}