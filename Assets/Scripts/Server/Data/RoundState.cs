using System;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.Bon;
using UnityEngine.Scripting;

/// <summary>
/// 战斗中的回合状态
/// <summary>
public partial class RoundState: DataBase {
    [Preserve]
    public RoundState() {
    }
    
    public long round = 0;
    public long maxHp = 0;
    public long hp = 0;
    public long maxMp = 0;
    public long mp = 0;
    public long weaponDamage = 0;
    public long armor = 0;
    public float critRate = 0;
    public float dodge = 0;
    public float stun = 0;
    public float comb = 0;
    public bool fireCrit = false;
    public bool fireDodge = false;
    public bool fireStun = false;
}