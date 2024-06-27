using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 天赋
/// <summary>
public partial class Talent: DataBase {
    [Preserve]
    public Talent() {
    }
    
    /// <summary>
    /// 天赋属性
    /// <summary>
    public string attr = string.Empty;
    /// <summary>
    /// 天赋数值
    /// <summary>
    public float value = 0;
}