using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public partial class Room_FrameMsgP: RespBase {
    public Room_FrameMsgP() {
    }
    
    /// <summary>
    /// 帧序号
    /// <summary>
    public long f = 0;
    /// <summary>
    /// 消息集合
    /// <summary>
    public List<Room_FrameMsgOne> l;
}