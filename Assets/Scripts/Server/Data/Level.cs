using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// pve 关卡信息
/// <summary>
public partial class Level: DataBase {
    [Preserve]
    public Level() {
    }
    
    public long id = 0;
    /// <summary>
    /// 角色 id
    /// <summary>
    public long roleId = 0;
    /// <summary>
    /// 英雄 id
    /// <summary>
    public long heroId = 0;
    /// <summary>
    /// 关卡编号
    /// <summary>
    public long level = 0;
    /// <summary>
    /// 敌人
    /// <summary>
    public Hero enemy = new Hero();
    /// <summary>
    /// 对战编号
    /// <summary>
    public long battleId = 0;
}