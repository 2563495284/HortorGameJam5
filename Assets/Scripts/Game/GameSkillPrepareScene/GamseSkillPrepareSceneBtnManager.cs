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

    public Text textBtnComfirm;
    private void Start()
    {
        btnComfirm.onClick.AddListener(OnClickBtnComfirm);
        btnCancel.onClick.AddListener(OnClickBtnCancel);
        switch (PlayerModel.Instance.battleType)
        {
            case EBattleType.EMPTY:
                break;
            case EBattleType.PVE:
                textBtnComfirm.text = "开始战斗";
                break;
            case EBattleType.PVP:
                textBtnComfirm.text = "匹配对手";
                break;
            default:
                break;
        }
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


        switch (PlayerModel.Instance.battleType)
        {
            case EBattleType.EMPTY:
                MessageManager.Instance.ShowMessage("你是怎么进来这个页面的？");
                break;
            case EBattleType.PVE:
                bool pevSuccecss = await PlayerModel.Instance.StartPevBattleAsync(heroId);
                if (!pevSuccecss)
                {
                    _waitingGame = false;
                    MessageManager.Instance.ShowMessage("游戏开始失败,请稍后重试");
                    return;
                }
                SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESCENE);
                break;
            case EBattleType.PVP:
                SceneSwitcher.LoadSceneByIndex(ESceneType.GAMEPVPQUEUEINGSCENE);
                break;
            case EBattleType.SELF:

                BattleFinishResp battleData = await PlayerModel.Instance.startBattle(heroId);
                if (battleData == null)
                {
                    _waitingGame = false;
                    MessageManager.Instance.ShowMessage("游戏开始失败,请稍后重试");
                    return;
                }
                SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESCENE);
                break;
        }
        _waitingGame = false;
    }
}
