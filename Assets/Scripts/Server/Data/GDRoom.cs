using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class GDRoom: DataBase {
    [Preserve]
    public GDRoom() {
    }
    
    /// <summary>
    /// 房间id
    /// <summary>
    public string id = string.Empty;
    /// <summary>
    /// 服务器id
    /// <summary>
    public string sid = string.Empty;
    /// <summary>
    /// 房间类型
    /// <summary>
    public string type = string.Empty;
    /// <summary>
    /// 房间版本号
    /// <summary>
    public string version = string.Empty;
    /// <summary>
    /// 房间名
    /// <summary>
    public string name = string.Empty;
    /// <summary>
    /// 房主id
    /// <summary>
    public long owner = 0;
    /// <summary>
    /// 房主名
    /// <summary>
    public string ownerName = string.Empty;
    /// <summary>
    /// 房间状态
    /// <summary>
    public string state = EMRoomState.idle;
    /// <summary>
    /// 自定义参数
    /// <summary>
    public Dictionary<string, object> custom = new Dictionary<string, object>();
    /// <summary>
    /// 分组数量
    /// <summary>
    public long groupNum = 0;
    /// <summary>
    /// 每个分组多少玩家
    /// <summary>
    public List<long> groupRoleNum = new List<long>();
    /// <summary>
    /// 自由模式成员列表
    /// <summary>
    public Dictionary<long, GDRoomRole> roles = new Dictionary<long, GDRoomRole>();
    /// <summary>
    /// 最大人数
    /// <summary>
    public long maxRoleNum = 0;
    /// <summary>
    /// 当前人数
    /// <summary>
    public long roleNum = 0;
    /// <summary>
    /// 剩余可加入人数
    /// <summary>
    public long freeRoleNum = 0;
    /// <summary>
    /// 锁定
    /// <summary>
    public bool locked = false;
    /// <summary>
    /// 创建时间
    /// <summary>
    public long createAt = 0;
    /// <summary>
    /// 分配id
    /// <summary>
    public int allocId = 0;
    /// <summary>
    /// 超时时间
    /// <summary>
    public long timeoutTime = 0;
    /// <summary>
    /// 帧同步帧率
    /// <summary>
    public long fps = 0;
    /// <summary>
    /// 帧同步开始时间
    /// <summary>
    public long frameSyncStartAt = 0;
}