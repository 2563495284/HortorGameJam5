using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRolePrepareSceneBtnManager : MonoBehaviour
{
    public Button btnComfirm;
    public Button btnBattleTest;

    public Button btnCancel;

    private void Start()
    {
        btnBattleTest.onClick.AddListener(OnClickbtnBattleTest);
        btnComfirm.onClick.AddListener(OnClickBtnConfim);
        btnCancel.onClick.AddListener(OnClickBtnCancel);
    }

    private void OnClickBtnConfim()
    {
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESKILLPREPARESCENE);
    }

    private void OnClickbtnBattleTest()
    {
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESKILLPREPARESCENE);
    }

    private void OnClickBtnCancel()
    {
        SceneSwitcher.LoadSceneByIndex(ESceneType.MAINSCENE);
    }
}