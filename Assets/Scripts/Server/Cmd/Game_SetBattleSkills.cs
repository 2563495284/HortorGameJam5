using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 调整上阵技能
/// <summary>
public partial class Game_SetBattleSkills: ReqBase {
    public Game_SetBattleSkills() {
    }
    
    /// <summary>
    /// 英雄 id
    /// <summary>
    public long heroId;
    /// <summary>
    /// 技能 id 列表
    /// <summary>
    public List<long> skillIds;
}