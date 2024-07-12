using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void OnClickBtnCancel()
    {
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMEROLEPREPARESCENE);
    }
    private bool _waitingGame = false;
    private async void OnClickBtnComfirm()
    {
        if (_waitingGame) return;
        _waitingGame = true;

        long heroId = PlayerModel.Instance.curtHero.id;
        List<long> skillsId = new List<long>();
        PlayerModel.Instance.skillList.ForEach(x => skillsId.Add(x.id));

        bool setRoleBattleSkillsSuccess = await PlayerModel.Instance.setRoleBattleSkills(heroId, skillsId);
        if (!setRoleBattleSkillsSuccess)
        {
            _waitingGame = false;
            MessageManager.Instance.ShowMessage("游戏开始失败,请稍后重试");
            return;
        }
        Battle battleData = await PlayerModel.Instance.startBattle(heroId);
        if (battleData == null)
        {
            _waitingGame = false;
            MessageManager.Instance.ShowMessage("游戏开始失败,请稍后重试");
            return;
        }
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESCENE);
        _waitingGame = false;
    }
}
