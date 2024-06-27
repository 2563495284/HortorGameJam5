using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public partial class Room_MsgP: RespBase {
    public Room_MsgP() {
    }
    
    public string roomId = string.Empty;
    public long roleId = 0;
    public object msg;
}