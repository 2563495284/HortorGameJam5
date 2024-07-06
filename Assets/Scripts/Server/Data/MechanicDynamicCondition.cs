using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 动态触发时机
/// <summary>
public partial class MechanicDynamicCondition: DataBase {
    [Preserve]
    public MechanicDynamicCondition() {
    }
    
    /// <summary>
    /// 触发目标
    /// <summary>
    public string target = string.Empty;
    /// <summary>
    /// 触发属性
    /// <summary>
    public string attr = string.Empty;
    /// <summary>
    /// 增加还是减少，后面可能支持表达式
    /// <summary>
    public long incOrDec = 0;
}