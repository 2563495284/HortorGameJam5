using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public partial class OIM_GetHistoryResp: RespBase {
    public OIM_GetHistoryResp() {
    }
    
    public List<OIMMsg> msgs;
}