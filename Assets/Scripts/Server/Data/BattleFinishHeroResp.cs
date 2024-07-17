using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 战斗结算中的英雄状态
/// <summary>
public partial class BattleFinishHeroResp: DataBase {
    [Preserve]
    public BattleFinishHeroResp() {
    }
    
    public long id = 0;
    /// <summary>
    /// 最大生命
    /// <summary>
    public long maxHp = 0;
    /// <summary>
    /// 当前生命
    /// <summary>
    public long hp = 0;
    /// <summary>
    /// 最大魔法值
    /// <summary>
    public long maxMp = 0;
    /// <summary>
    /// 当前魔法
    /// <summary>
    public long mp = 0;
    /// <summary>
    /// 武器伤害
    /// <summary>
    public long weaponDamage = 0;
    /// <summary>
    /// 护甲
    /// <summary>
    public long armor = 0;
    /// <summary>
    /// 暴击率
    /// <summary>
    public float critRate = 0;
    /// <summary>
    /// 闪避率
    /// <summary>
    public float dodge = 0;
    /// <summary>
    /// 眩晕率
    /// <summary>
    public float stun = 0;
    /// <summary>
    /// 连击率
    /// <summary>
    public float comb = 0;
    /// <summary>
    /// 是否处于眩晕状态
    /// <summary>
    public bool isStun = false;
}