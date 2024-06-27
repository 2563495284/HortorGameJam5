using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 获取房间列表
/// <summary>
public partial class Room_List: ReqBase {
    public Room_List() {
    }
    
    /// <summary>
    /// 筛选条件 https://docs.mongodb.com/manual/reference/operator/query/#query-selectors
    /// <summary>
    public Dictionary<string, object> filter;
    /// <summary>
    /// skip
    /// <summary>
    public long skip;
    /// <summary>
    /// limit
    /// <summary>
    public long limit;
}