using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class StartSceneBtnManager : MonoBehaviour
{
    public Button startBtn;

    public Dropdown languageDropdown;

    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(OnClickStartBtn);

        languageDropdown.onValueChanged.AddListener(SelectLanguage);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnDestroy()
    {

    }
    #region startBtn
    private void OnClickStartBtn()
    {
        if (!PlayerModel.Instance.finishLogin)
        {
            MessageManager.Instance.ShowMessage("登陆中～");
            return;
        }
        if (PlayerModel.Instance.curtHero == null)
        {
            SceneSwitcher.LoadSceneByIndex(ESceneType.CARDBAGSCENE);
        }
        else
        {
            SceneSwitcher.LoadSceneByIndex(ESceneType.MAINSCENE);
        }
    }
    #endregion
    #region language
    public void SelectLanguage(int value)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[value];
    }
    #endregion
}
