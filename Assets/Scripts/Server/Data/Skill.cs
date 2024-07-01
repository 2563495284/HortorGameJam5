using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 技能
/// <summary>
public partial class CardSkill: DataBase {
    [Preserve]
    public CardSkill() {
    }
    
    /// <summary>
    /// 名称
    /// <summary>
    public string name = string.Empty;
    /// <summary>
    /// 耗蓝
    /// <summary>
    public long mp = 0;
    /// <summary>
    /// 技能描述
    /// <summary>
    public string desc = string.Empty;
    /// <summary>
    /// 机制列表
    /// <summary>
    public List<SkillMechanic> mechanics = new List<SkillMechanic>();
}