using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 发送房间消息
/// <summary>
public partial class Room_Msg: ReqBase {
    public Room_Msg() {
    }
    
    /// <summary>
    /// 房间id
    /// <summary>
    public string roomId;
    /// <summary>
    /// 发送目标
    /// <summary>
    public EMRoomMsgTarget target;
    /// <summary>
    /// 发送目标id列表
    /// <summary>
    public List<long> ids;
    /// <summary>
    /// 消息内容
    /// <summary>
    public object msg;
}