using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}

