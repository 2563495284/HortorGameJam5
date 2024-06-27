using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public partial class Login_AuthUser: ReqBase {
    public Login_AuthUser() {
    }
    
    /// <summary>
    /// 平台,debug,hortor
    /// <summary>
    public string platform;
    /// <summary>
    /// 平台认证信息,包含加密的用户信息
    /// <summary>
    public string info;
    /// <summary>
    /// 微信小程序场景
    /// <summary>
    public int scene;
    /// <summary>
    /// 微信小程序跳转来源信息
    /// <summary>
    public string referrerInfo;
}