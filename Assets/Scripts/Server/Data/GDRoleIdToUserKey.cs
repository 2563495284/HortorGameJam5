using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 角色id到user key的映射，用于首次登录
/// <summary>
public partial class GDRoleIdToUserKey: DataBase {
    [Preserve]
    public GDRoleIdToUserKey() {
    }
    
    /// <summary>
    /// 角色id
    /// <summary>
    public long roleId = 0;
    /// <summary>
    /// 用户键值
    /// <summary>
    public string uKey = string.Empty;
}