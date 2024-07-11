using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 设置启用英雄
/// <summary>
public partial class Game_SetActiveHero: ReqBase {
    public Game_SetActiveHero() {
    }
    
    public long heroId;
}