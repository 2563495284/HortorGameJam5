using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 角色
/// <summary>
public partial class GDRole: DataBase {
    [Preserve]
    public GDRole() {
    }
    
    /// <summary>
    /// 角色id
    /// <summary>
    public long id = 0;
    /// <summary>
    /// 用户id
    /// <summary>
    public long uId = 0;
    /// <summary>
    /// 服务器id
    /// <summary>
    public long sId = 0;
    /// <summary>
    /// 用户键值
    /// <summary>
    public string uKey = string.Empty;
    /// <summary>
    /// 用户信息
    /// <summary>
    public GDUserInfo userInfo = new GDUserInfo();
    /// <summary>
    /// 等级
    /// <summary>
    public int lv = 0;
    /// <summary>
    /// 金币
    /// <summary>
    public long gold = 0;
    /// <summary>
    /// 物品列表
    /// <summary>
    public Dictionary<int, GDItem> items = new Dictionary<int, GDItem>();
    /// <summary>
    /// 形象
    /// <summary>
    public List<string> avatar = new List<string>();
    /// <summary>
    /// 英雄列表
    /// <summary>
    public List<Hero> heros = new List<Hero>();
}