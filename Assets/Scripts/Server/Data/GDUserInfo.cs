using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class GDUserInfo: DataBase {
    [Preserve]
    public GDUserInfo() {
    }
    
    public string name = string.Empty;
    public string img = string.Empty;
    public EMSex sex = EMSex.unknown;
    public string province = string.Empty;
    public string city = string.Empty;
}