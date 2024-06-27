using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 解锁房间
/// <summary>
public partial class Room_Unlock: ReqBase {
    public Room_Unlock() {
    }
    
    /// <summary>
    /// 房间id
    /// <summary>
    public string roomId;
}