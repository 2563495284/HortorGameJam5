using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamseSkillPrepareSceneBtnManager : MonoBehaviour
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
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESCENE);
    }
    private void OnClickBtnCancel()
    {

        // PlayerModel.Instance.
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMEROLEPREPARESCENE);
    }
}
