using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public partial class Game_GetHero: ReqBase {
    public Game_GetHero() {
    }
    
    /// <summary>
    /// 英雄 id
    /// <summary>
    public long heroId;
}