using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneBtnManager : MonoBehaviour
{
    public Button startBtn;
    public Button cardBagBtn;
    public Text levelText;

    public GameObject pveEnemy;
    public GameObject pveEnemyLoading;

    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(OnClickStartBtn);
        cardBagBtn.onClick.AddListener(OnClickCardBagBtn);
        PlayerModel.Instance.GetNextPveEnemyInfoAsync();
        RefreshPveEnemy(PlayerModel.Instance.PveLevel);
        PlayerModel.Instance.e.StartListening<Level>(EGameEvent.NEXT_LEVEL_REFRESH, RefreshPveEnemy);
        PlayerModel.Instance.e.StartListening<Hero>(EGameEvent.SHORT_CLICK_ROLE, OnClickPevBtn);
        PlayerModel.Instance.e.StartListening<Hero>(EGameEvent.LONG_CLICK_ROLE, ShowPveEnemyInfo);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerModel.Instance.role?.heros?.Count == 0)
        {
            startBtn.enabled = false;
        }
        else
        {
            startBtn.enabled = true;
        }
    }

    private void OnClickStartBtn()
    {
        MessageManager.Instance.ShowMessage("ShowMessage : OnClickStartBtn");
        Debug.Log("OnClickStartBtn");
        PlayerModel.Instance.battleType = EBattleType.PVP;
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMEROLEPREPARESCENE);
    }

    private void OnClickCardBagBtn()
    {
        MessageManager.Instance.ShowMessage("ShowMessage : OnClickCardBagBtn");
        Debug.Log("OnClickCardBagBtn");
        SceneSwitcher.LoadSceneByIndex(ESceneType.CARDBAGSCENE);
    }

    private void RefreshPveEnemy(Level level)
    {
        if (level != null)
        {
            var hero = level.enemy;
            RoleRender roleRender = pveEnemy.GetComponent<RoleRender>();
            roleRender.OnData(hero);
            levelText.text = $"第 {level.level} 关";
            pveEnemy.SetActive(true);
            pveEnemyLoading.SetActive(false);
        }
        else
        {
            pveEnemy.SetActive(false);
            pveEnemyLoading.SetActive(true);
        }
    }

    private void ShowPveEnemyInfo(Hero hero)
    {
        if (hero == null) return;
        HeroInfoView.Instance.ShowHeroInfoView(hero);
    }

    void OnDestroy()
    {
        PlayerModel.Instance.e.StopListening<Level>(EGameEvent.NEXT_LEVEL_REFRESH, RefreshPveEnemy);
        PlayerModel.Instance.e.StopListening<Hero>(EGameEvent.SHORT_CLICK_ROLE, OnClickPevBtn);
        PlayerModel.Instance.e.StopListening<Hero>(EGameEvent.LONG_CLICK_ROLE, ShowPveEnemyInfo);
    }

    #region PveBtn

    private void OnClickPevBtn(Hero hero)
    {
        PlayerModel.Instance.battleType = EBattleType.PVE;
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMEROLEPREPARESCENE);
    }

    #endregion
}