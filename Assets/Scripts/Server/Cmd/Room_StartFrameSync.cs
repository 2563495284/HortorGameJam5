using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 开启帧同步
/// <summary>
public partial class Room_StartFrameSync: ReqBase {
    public Room_StartFrameSync() {
    }
    
    /// <summary>
    /// 房间id
    /// <summary>
    public string roomId;
    /// <summary>
    /// 帧率
    /// <summary>
    public long fps;
}