using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public partial class OIM_GetHistory: ReqBase {
    public OIM_GetHistory() {
    }
    
    public OIMConversationType convType;
    public long id;
    public long lastId;
}