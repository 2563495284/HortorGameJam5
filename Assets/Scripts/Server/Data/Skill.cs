using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 技能
/// <summary>
public partial class Skill: DataBase {
    [Preserve]
    public Skill() {
    }
    
    /// <summary>
    /// id
    /// <summary>
    public long id = 0;
    /// <summary>
    /// 名称
    /// <summary>
    public string name = string.Empty;
    /// <summary>
    /// 耗蓝
    /// <summary>
    public long mp = 0;
    /// <summary>
    /// 文案
    /// <summary>
    public string text = string.Empty;
    /// <summary>
    /// 技能描述
    /// <summary>
    public string desc = string.Empty;
    /// <summary>
    /// 机制列表
    /// <summary>
    public List<SkillMechanic> mechanics = new List<SkillMechanic>();
    /// <summary>
    /// 技能属性摘要
    /// <summary>
    public List<string> attrSummary = new List<string>();
}