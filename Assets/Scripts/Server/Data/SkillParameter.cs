using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 机制参数
/// <summary>
public partial class SkillParameter: DataBase {
    [Preserve]
    public SkillParameter() {
    }
    
    /// <summary>
    /// 时机
    /// <summary>
    public string condition = string.Empty;
    /// <summary>
    /// 触发概率
    /// <summary>
    public float prob = 0;
    /// <summary>
    /// 源属性
    /// <summary>
    public string sourceAttr = string.Empty;
    /// <summary>
    /// 目标属性
    /// <summary>
    public string targetAttr = string.Empty;
    /// <summary>
    /// 运算符
    /// <summary>
    public string op = string.Empty;
    /// <summary>
    /// 变化数值
    /// <summary>
    public float value = 0;
    /// <summary>
    /// 天赋加成
    /// <summary>
    public float talentValue = 0;
}