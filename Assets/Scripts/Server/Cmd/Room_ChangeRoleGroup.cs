using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 调整玩家分组信息
/// <summary>
public partial class Room_ChangeRoleGroup: ReqBase {
    public Room_ChangeRoleGroup() {
    }
    
    /// <summary>
    /// 房间id
    /// <summary>
    public string roomId;
    /// <summary>
    /// 玩家id
    /// <summary>
    public long roleId;
    /// <summary>
    /// 新分组
    /// <summary>
    public long group;
    /// <summary>
    /// 分组中的位置
    /// <summary>
    public long idxInGroup;
}