using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class OMailUserMail: DataBase {
    [Preserve]
    public OMailUserMail() {
    }
    
    /// <summary>
    /// 邮件id
    /// <summary>
    public long id = 0;
    /// <summary>
    /// 接收者id
    /// <summary>
    public long roleId = 0;
    /// <summary>
    /// 接收者服务器id
    /// <summary>
    public long serverId = 0;
    /// <summary>
    /// 邮件类型
    /// <summary>
    public OMailMailType type = OMailMailType.user;
    /// <summary>
    /// 邮件分类
    /// <summary>
    public long category = 0;
    /// <summary>
    /// 发送者id
    /// <summary>
    public long fromId = 0;
    /// <summary>
    /// 发送者名
    /// <summary>
    public string from = string.Empty;
    /// <summary>
    /// 标题
    /// <summary>
    public string title = string.Empty;
    /// <summary>
    /// 内容
    /// <summary>
    public string content = string.Empty;
    /// <summary>
    /// 创建时间
    /// <summary>
    public long createdAt = 0;
    /// <summary>
    /// 过期时间
    /// <summary>
    public long expireAt = 0;
    /// <summary>
    /// 邮件状态
    /// <summary>
    public OMailState state = OMailState.pending;
    /// <summary>
    /// 是否有附件
    /// <summary>
    public bool haveAttachments = false;
    /// <summary>
    /// 附件
    /// <summary>
    public List<OMailAttachment> attachments = new List<OMailAttachment>();
    /// <summary>
    /// 扩展类型
    /// <summary>
    public string extType = string.Empty;
    /// <summary>
    /// 扩展内容
    /// <summary>
    public string ext = string.Empty;
    /// <summary>
    /// 自定义内容
    /// <summary>
    public object custom = null;
}