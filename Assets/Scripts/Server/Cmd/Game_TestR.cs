using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public partial class Game_TestR: RespBase {
    public Game_TestR() {
    }
    
    public object data;
    public Dictionary<string, GDRole> map;
    public List<GDRole> slice;
}