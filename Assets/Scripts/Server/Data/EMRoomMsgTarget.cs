using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 发送目标枚举
/// <summary>
public enum EMRoomMsgTarget {
    all = 0,
    others = 1,
    ids = 2,
    master = 3,
    allClients = 4,
}