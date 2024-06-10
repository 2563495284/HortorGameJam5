using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class StartSceneBtnManager : MonoBehaviour
{
    public Button startBtn;
    public Button languageBtn;
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
        SceneSwitcher.LoadSceneByIndex(ESceneType.MAINSCENE);
    }
    #endregion
    #region languageBtn
    private void OnClickLanguagetBtn()
    {
        MessageManager.Instance.ShowMessage("ShowMessage : OnClickLanguagetBtn");
        //LocalizationSettings.
    }
    public void SelectLanguage(int value)
    {
        //��������ǰѡ��ѡ����±���Ϊ�������õ�LocalizationSettings��SelectedLocale�ﵽʵ�������л���Ч��
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[value];
    }
    #endregion
}
