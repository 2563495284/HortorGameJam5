using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 子游戏
/// <summary>
public partial class GDSubGame: DataBase {
    [Preserve]
    public GDSubGame() {
    }
    
    /// <summary>
    /// id
    /// <summary>
    public string id = string.Empty;
    /// <summary>
    /// 名字
    /// <summary>
    public string name = string.Empty;
    /// <summary>
    /// 描述
    /// <summary>
    public string desc = string.Empty;
    /// <summary>
    /// 最新版本
    /// <summary>
    public string version = string.Empty;
    /// <summary>
    /// 作者id
    /// <summary>
    public long creatorId = 0;
    /// <summary>
    /// 作者名
    /// <summary>
    public string creatorName = string.Empty;
    /// <summary>
    /// 创建时间
    /// <summary>
    public long createAt = 0;
}