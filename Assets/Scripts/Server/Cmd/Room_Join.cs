using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 加入房间
/// <summary>
public partial class Room_Join: ReqBase {
    public Room_Join() {
    }
    
    /// <summary>
    /// 房间id
    /// <summary>
    public string roomId;
    /// <summary>
    /// 房间版本
    /// <summary>
    public string version;
    /// <summary>
    /// 房间密码
    /// <summary>
    public string password;
    /// <summary>
    /// 自己的信息
    /// <summary>
    public Dictionary<string, object> custom;
    /// <summary>
    /// 期待的分组
    /// <summary>
    public long preferGroup;
}