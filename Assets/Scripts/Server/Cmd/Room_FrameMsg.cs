using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 发送帧同步消息
/// <summary>
public partial class Room_FrameMsg: ReqBase {
    public Room_FrameMsg() {
    }
    
    /// <summary>
    /// 房间id
    /// <summary>
    public string r;
    /// <summary>
    /// 期望帧序号
    /// <summary>
    public long f;
    /// <summary>
    /// 内容
    /// <summary>
    public byte[] d;
}