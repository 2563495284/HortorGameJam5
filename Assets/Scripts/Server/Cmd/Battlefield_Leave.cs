using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 离开战场
/// <summary>
public partial class Battlefield_Leave: ReqBase {
    public Battlefield_Leave() {
    }
    
    /// <summary>
    /// 战场id
    /// <summary>
    public string bfId;
}