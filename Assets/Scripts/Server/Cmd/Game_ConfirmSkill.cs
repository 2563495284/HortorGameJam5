using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 加入技能库
/// <summary>
public partial class Game_ConfirmSkill: ReqBase {
    public Game_ConfirmSkill() {
    }
    
    /// <summary>
    /// 英雄 id
    /// <summary>
    public long heroId;
    /// <summary>
    /// 技能 id
    /// <summary>
    public long skillId;
}