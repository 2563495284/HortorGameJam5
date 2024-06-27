using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 根据战场id获取战场服务器id
/// <summary>
public partial class Battlefield_GetServer: ReqBase {
    public Battlefield_GetServer() {
    }
    
    public string bfId;
}