using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public partial class OIM_SendMsg: ReqBase {
    public OIM_SendMsg() {
    }
    
    public OIMConversationType convType;
    public List<long> toIds;
    public OIMContentType contType;
    public string content;
    public string extra;
}