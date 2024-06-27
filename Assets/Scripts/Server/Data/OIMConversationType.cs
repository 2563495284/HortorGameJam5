using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public enum OIMConversationType {
    system = 0,
    /// <summary>
    /// 私聊消息，发给双方
    /// <summary>
    peer = 1,
    chatRoom = 3,
    world = 4,
    server = 5,
    /// <summary>
    /// 私聊消息，只发给对方
    /// <summary>
    peerOneWay = 6,
    /// <summary>
    /// 私聊消息，只发给自己
    /// <summary>
    peerSelf = 7,
}