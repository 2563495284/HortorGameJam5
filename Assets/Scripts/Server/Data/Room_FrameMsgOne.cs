using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class Room_FrameMsgOne: DataBase {
    [Preserve]
    public Room_FrameMsgOne() {
    }
    
    /// <summary>
    /// 玩家id
    /// <summary>
    public long r = 0;
    /// <summary>
    /// 数据
    /// <summary>
    public byte[] d = null;
}