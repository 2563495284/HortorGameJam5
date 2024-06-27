using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class GDRoomRole: DataBase {
    [Preserve]
    public GDRoomRole() {
    }
    
    public long id = 0;
    public GDUserInfo userInfo = new GDUserInfo();
    public Dictionary<string, object> custom = new Dictionary<string, object>();
    public long group = 0;
    public long idxInGroup = 0;
    public int allocId = 0;
}