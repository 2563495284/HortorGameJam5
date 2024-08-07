using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 英雄
/// <summary>
public partial class Hero: DataBase {
    [Preserve]
    public Hero() {
    }
    
    /// <summary>
    /// 角色id
    /// <summary>
    public long id = 0;
    /// <summary>
    /// 头像 base64
    /// <summary>
    public string avatar = string.Empty;
    /// <summary>
    /// 英雄名称
    /// <summary>
    public string name = string.Empty;
    /// <summary>
    /// 生命值
    /// <summary>
    public long hp = 0;
    /// <summary>
    /// 魔法值
    /// <summary>
    public long mp = 0;
    /// <summary>
    /// 武器伤害
    /// <summary>
    public long weaponDamage = 0;
    /// <summary>
    /// 天赋
    /// <summary>
    public Talent talent = new Talent();
    /// <summary>
    /// 技能列表
    /// <summary>
    public List<Skill> skills = new List<Skill>();
    /// <summary>
    /// 战斗技能卡组
    /// <summary>
    public List<Skill> battleSkills = new List<Skill>();
    /// <summary>
    /// 未确认的技能
    /// <summary>
    public Skill tmpSkill = new Skill();
}