using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 根据房间id获取房间服务器id
/// <summary>
public partial class Room_GetServer: ReqBase {
    public Room_GetServer() {
    }
    
    public string roomId;
}