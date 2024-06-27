using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 补帧，遗漏的帧会分批发送到客户端，客户端需要做缓冲处理
/// <summary>
public partial class Room_GetLostFrameMsg: ReqBase {
    public Room_GetLostFrameMsg() {
    }
    
    /// <summary>
    /// 房间id
    /// <summary>
    public string roomId;
    /// <summary>
    /// 起始帧(含)
    /// <summary>
    public long startFrame;
    /// <summary>
    /// 结束帧(含)
    /// <summary>
    public long endFrame;
}