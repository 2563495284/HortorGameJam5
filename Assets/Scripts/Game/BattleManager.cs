using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    Battle _battleData;
    public Battle battleData
    {
        get
        {
            return battleData;
        }
    }
    public void SetBattleManager(Battle data)
    {
        _battleData = data;
    }
}
