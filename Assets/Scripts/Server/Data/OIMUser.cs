using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class OIMUser: DataBase {
    [Preserve]
    public OIMUser() {
    }
    
    public long id = 0;
    public string name = string.Empty;
    public string avatar = string.Empty;
    public string extra = string.Empty;
}