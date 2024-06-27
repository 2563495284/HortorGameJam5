using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public static class EMRoomState {
    /// <summary>
    /// 空闲
    /// <summary>
    public const string idle = "idle";
    /// <summary>
    /// 开始中
    /// <summary>
    public const string starting = "starting";
    /// <summary>
    /// 已开始
    /// <summary>
    public const string started = "started";
    /// <summary>
    /// 帧同步开启中
    /// <summary>
    public const string frameSyncing = "frameSyncing";
    /// <summary>
    /// 已结束
    /// <summary>
    public const string ended = "ended";
}