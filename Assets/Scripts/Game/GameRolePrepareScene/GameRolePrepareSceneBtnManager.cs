using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRolePrepareSceneBtnManager : MonoBehaviour
{
    public Button btnComfirm;

    public Button btnCancel;

    private void Start()
    {
        btnComfirm.onClick.AddListener(OnClickBtnComfirm);
        btnCancel.onClick.AddListener(OnClickBtnCancel);
    }
    private void OnClickBtnComfirm()
    {
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESKILLPREPARESCENE);
    }
    private void OnClickBtnCancel()
    {
        SceneSwitcher.LoadSceneByIndex(ESceneType.MAINSCENE);
    }
}
