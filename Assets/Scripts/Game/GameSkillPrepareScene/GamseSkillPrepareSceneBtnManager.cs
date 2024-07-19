using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
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
        long heroId = PlayerModel.Instance.curtHero.id;
        switch (PlayerModel.Instance.battleType)
        {
            case EBattleType.EMPTY:
                MessageManager.Instance.ShowMessage("你是怎么进来这个页面的？");
                break;
            case EBattleType.PVE:
                if (_waitingGame) return;
                _waitingGame = true;
                bool pevSuccecss = await PlayerModel.Instance.StartPevBattleAsync(heroId);
                if (!pevSuccecss)
                {
                    _waitingGame = false;
                    MessageManager.Instance.ShowMessage("游戏开始失败,请稍后重试");
                    return;
                }
                SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESCENE);
                _waitingGame = false;
                break;
            case EBattleType.PVP:
                MessageManager.Instance.ShowMessage("还没做～");
                break;
            case EBattleType.SELF:

                if (_waitingGame) return;
                _waitingGame = true;

                List<long> skillsId = new List<long>();
                PlayerModel.Instance.skillList.ForEach(x => skillsId.Add(x.id));

                bool setRoleBattleSkillsSuccess = await PlayerModel.Instance.setRoleBattleSkills(heroId, skillsId);
                if (!setRoleBattleSkillsSuccess)
                {
                    _waitingGame = false;
                    MessageManager.Instance.ShowMessage("游戏开始失败,请稍后重试");
                    return;
                }
                BattleFinishResp battleData = await PlayerModel.Instance.startBattle(heroId);
                if (battleData == null)
                {
                    _waitingGame = false;
                    MessageManager.Instance.ShowMessage("游戏开始失败,请稍后重试");
                    return;
                }
                SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESCENE);
                _waitingGame = false;
                break;
        }
    }
}
