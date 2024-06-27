using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 查询空闲房间id列表
/// <summary>
public partial class Room_FreeIdList: ReqBase {
    public Room_FreeIdList() {
    }
    
    /// <summary>
    /// 房间版本
    /// <summary>
    public string version;
    /// <summary>
    /// 筛选条件 https://docs.mongodb.com/manual/reference/operator/query/#query-selectors
    /// <summary>
    public Dictionary<string, object> filter;
    /// <summary>
    /// limit
    /// <summary>
    public long limit;
}