using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 创建房间
/// <summary>
public partial class Room_Create: ReqBase {
    public Room_Create() {
    }
    
    /// <summary>
    /// 类型
    /// <summary>
    public string type;
    /// <summary>
    /// 版本
    /// <summary>
    public string version;
    /// <summary>
    /// 名称
    /// <summary>
    public string name;
    /// <summary>
    /// 每组多少人
    /// <summary>
    public List<long> groupRoleNum;
    /// <summary>
    /// 自己的信息
    /// <summary>
    public Dictionary<string, object> custom;
    /// <summary>
    /// 密码
    /// <summary>
    public string password;
    /// <summary>
    /// 自定义属性
    /// <summary>
    public Dictionary<string, object> roomCustom;
    /// <summary>
    /// 是否使用master
    /// <summary>
    public bool useMaster;
    /// <summary>
    /// 是否模拟master，正式服无效
    /// <summary>
    public bool simMaster;
}