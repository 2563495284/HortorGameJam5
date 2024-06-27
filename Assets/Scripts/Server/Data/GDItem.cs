using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class GDItem: DataBase {
    [Preserve]
    public GDItem() {
    }
    
    public int i = 0;
    public int t = 0;
    public int n = 0;
    public GDTest test = new GDTest();
}