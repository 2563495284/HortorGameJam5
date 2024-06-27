using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public partial class OIM_GetConversationListResp: RespBase {
    public OIM_GetConversationListResp() {
    }
    
    public List<OIMConversation> convs;
}