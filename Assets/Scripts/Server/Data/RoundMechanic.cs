using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 战斗中的条件机制
/// <summary>
public partial class RoundMechanic: DataBase {
    [Preserve]
    public RoundMechanic() {
    }
    
    /// <summary>
    /// 生效的最后一回合
    /// <summary>
    public long round = 0;
    /// <summary>
    /// 机制
    /// <summary>
    public SkillMechanic mechanic = new SkillMechanic();
}