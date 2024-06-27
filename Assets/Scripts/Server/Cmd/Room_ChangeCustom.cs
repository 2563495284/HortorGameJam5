using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 更新房间自定义消息
/// <summary>
public partial class Room_ChangeCustom: ReqBase {
    public Room_ChangeCustom() {
    }
    
    /// <summary>
    /// 房间id
    /// <summary>
    public string roomId;
    /// <summary>
    /// 房间自定义信息
    /// <summary>
    public Dictionary<string, object> custom;
}