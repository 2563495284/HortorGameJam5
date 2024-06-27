using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class OIMConversation: DataBase {
    [Preserve]
    public OIMConversation() {
    }
    
    public OIMConversationType convType = OIMConversationType.system;
    public long oppId = 0;
    public OIMUser oppInfo = new OIMUser();
    public long time = 0;
}