using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneBtnManager : MonoBehaviour
{
    public Button actionBtn;
    public BattleSystem battleSystem;

    private void Awake()
    {
        actionBtn.onClick.AddListener(OnClickActionBtn);
    }
    private void OnClickActionBtn()
    {
        battleSystem.OnAttackButton();
    }
}
