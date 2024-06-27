using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class OIMMsg: DataBase {
    [Preserve]
    public OIMMsg() {
    }
    
    public long id = 0;
    public OIMUser from = new OIMUser();
    public long oppId = 0;
    public long time = 0;
    public OIMConversationType convType = OIMConversationType.system;
    public OIMContentType contType = OIMContentType.text;
    public string content = string.Empty;
    public string extra = string.Empty;
}