using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 用户
/// <summary>
public partial class GDUser: DataBase {
    [Preserve]
    public GDUser() {
    }
    
    /// <summary>
    /// 用户id
    /// <summary>
    public long id = 0;
    /// <summary>
    /// 用于查询的唯一key
    /// <summary>
    public string key = string.Empty;
    /// <summary>
    /// 平台
    /// <summary>
    public string platform = string.Empty;
    /// <summary>
    /// 平台用户id
    /// <summary>
    public string platformUId = string.Empty;
    /// <summary>
    /// 平台ID
    /// <summary>
    public long platformId = 0;
    /// <summary>
    /// 微信小游戏 openId
    /// <summary>
    public string openId = string.Empty;
    /// <summary>
    /// 微信 unionID
    /// <summary>
    public string unionId = string.Empty;
    /// <summary>
    /// 用户信息
    /// <summary>
    public string userName = string.Empty;
    /// <summary>
    /// 头像
    /// <summary>
    public string userImg = string.Empty;
    /// <summary>
    /// 性别， 0：未知，1：男，2：女
    /// <summary>
    public EMSex userSex = EMSex.unknown;
    /// <summary>
    /// 分享码
    /// <summary>
    public string shareCode = string.Empty;
    /// <summary>
    /// 登录的平台
    /// <summary>
    public string loginPlatform = string.Empty;
    /// <summary>
    /// 登录方式
    /// <summary>
    public string loginType = string.Empty;
    /// <summary>
    /// 省
    /// <summary>
    public string province = string.Empty;
    /// <summary>
    /// 市
    /// <summary>
    public string city = string.Empty;
    /// <summary>
    /// 是否显示关注
    /// <summary>
    public bool isSubscribe = false;
    /// <summary>
    /// 是否授权
    /// <summary>
    public bool authed = false;
    /// <summary>
    /// 所属渠道
    /// <summary>
    public string channel = string.Empty;
    /// <summary>
    /// 微信场景
    /// <summary>
    public int scene = 0;
    /// <summary>
    /// 微信来源
    /// <summary>
    public string referrerInfo = string.Empty;
    /// <summary>
    /// 注册时间
    /// <summary>
    public long regTime = 0;
    /// <summary>
    /// 设备id
    /// <summary>
    public string deviceId = string.Empty;
    /// <summary>
    /// 封禁信息
    /// <summary>
    public GDBanInfo ban = new GDBanInfo();
    /// <summary>
    /// 平台信息LoginFrom=>Info
    /// <summary>
    public Dictionary<string, object> platformInfos = new Dictionary<string, object>();
    /// <summary>
    /// 关联的平台用户id
    /// <summary>
    public List<string> morePlatformUIds = new List<string>();
    public Dictionary<long, GDServerRole> roles = new Dictionary<long, GDServerRole>();
}