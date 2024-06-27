using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 创建技能
/// <summary>
public partial class Game_CreateSkill: ReqBase {
    public Game_CreateSkill() {
    }
    
    /// <summary>
    /// 所属英雄
    /// <summary>
    public long heroId;
    /// <summary>
    /// 技能描述
    /// <summary>
    public string desc;
}