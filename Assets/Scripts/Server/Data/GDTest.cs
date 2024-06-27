using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class GDTest: DataBase {
    [Preserve]
    public GDTest() {
    }
    
    public int a = 0;
    public int b = 0;
    public List<long> c = new List<long>();
}