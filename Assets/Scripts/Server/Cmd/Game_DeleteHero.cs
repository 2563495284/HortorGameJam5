using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 删除英雄
/// <summary>
public partial class Game_DeleteHero: ReqBase {
    public Game_DeleteHero() {
    }
    
    /// <summary>
    /// 英雄 id
    /// <summary>
    public long heroId;
}