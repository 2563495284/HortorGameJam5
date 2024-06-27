using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

public partial class OMailAttachment: DataBase {
    [Preserve]
    public OMailAttachment() {
    }
    
    /// <summary>
    /// 附件类型
    /// <summary>
    public string type = string.Empty;
    /// <summary>
    /// 附件id
    /// <summary>
    public string id = string.Empty;
    /// <summary>
    /// 附件数量
    /// <summary>
    public long num = 0;
    /// <summary>
    /// 附件扩展内容
    /// <summary>
    public string ext = string.Empty;
}