using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class StartSceneBtnHandler : MonoBehaviour
{
    public Button startBtn;
    public Button languageBtn;
    public SceneSwitcher sceneSwitcher;
    public Dropdown languageDropdown;

    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(OnClickStartBtn);
        languageBtn.onClick.AddListener(OnClickLanguagetBtn);
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
        sceneSwitcher.LoadSceneByIndex(1);
    }
    #endregion
    #region languageBtn
    private void OnClickLanguagetBtn()
    {
        MessageManager.Instance.ShowMessage("ShowMessage : OnClickLanguagetBtn");
    }
    public void SelectLanguage(int value)
    {
        //将下拉框当前选中选项的下标作为参数设置到LocalizationSettings的SelectedLocale达到实现语言切换的效果
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[value];
    }
    #endregion
}
