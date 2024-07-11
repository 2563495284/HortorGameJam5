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
    /// 下一个触发回合
    /// <summary>
    public long nextRound = 0;
    /// <summary>
    /// 生效的第一个回合
    /// <summary>
    public long firstRound = 0;
    /// <summary>
    /// 作用回合数
    /// <summary>
    public long round = 0;
    /// <summary>
    /// 机制
    /// <summary>
    public SkillMechanic mechanic = new SkillMechanic();
}