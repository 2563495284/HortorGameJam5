using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public enum EMBattlefieldState {
    /// <summary>
    /// 初始化
    /// <summary>
    init = 0,
    /// <summary>
    /// 等待开始
    /// <summary>
    waitStart = 10,
    /// <summary>
    /// 已开始
    /// <summary>
    started = 20,
    /// <summary>
    /// 已结束
    /// <summary>
    ended = 90,
}