using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class GDBattlefieldRole: DataBase {
    [Preserve]
    public GDBattlefieldRole() {
    }
    
    public long id = 0;
    public GDUserInfo userInfo = new GDUserInfo();
    public long group = 0;
}