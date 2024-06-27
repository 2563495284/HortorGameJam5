using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 机制
/// <summary>
public partial class SkillMechanic: DataBase {
    [Preserve]
    public SkillMechanic() {
    }
    
    /// <summary>
    /// 作用目标
    /// <summary>
    public string target = string.Empty;
    /// <summary>
    /// 持续回合
    /// <summary>
    public long round = 0;
    /// <summary>
    /// 参数列表
    /// <summary>
    public SkillParameter parameters = new SkillParameter();
}