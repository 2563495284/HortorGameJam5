using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 增加道具示例
/// <summary>
public partial class Game_AddItem: ReqBase {
    public Game_AddItem() {
    }
    
    /// <summary>
    /// 道具id
    /// <summary>
    public int id;
    /// <summary>
    /// 增加的数量，负数表示减少
    /// <summary>
    public int num;
}