using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 创建英雄
/// <summary>
public partial class Game_CreateHero: ReqBase {
    public Game_CreateHero() {
    }
    
    /// <summary>
    /// 英雄名称
    /// <summary>
    public string name;
}