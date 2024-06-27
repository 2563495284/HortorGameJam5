using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public enum OMailState {
    /// <summary>
    /// 等待发送
    /// <summary>
    pending = 0,
    /// <summary>
    /// 新邮件
    /// <summary>
    newMail = 1,
    /// <summary>
    /// 已读
    /// <summary>
    read = 2,
    /// <summary>
    /// 附件已领
    /// <summary>
    attachmentGot = 3,
    /// <summary>
    /// 已删除
    /// <summary>
    deleted = 9,
}