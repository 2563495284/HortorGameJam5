using UnityEngine;
using UnityEngine.UI;

public class MainSceneBtnManager : MonoBehaviour
{
    public Button startBtn;
    public Button cardBagBtn;
    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(OnClickStartBtn);
        cardBagBtn.onClick.AddListener(OnClickCardBagBtn);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnClickStartBtn()
    {
        MessageManager.Instance.ShowMessage("ShowMessage : OnClickStartBtn");
        Debug.Log("OnClickStartBtn");
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESCENE);
    }
    private void OnClickCardBagBtn()
    {
        MessageManager.Instance.ShowMessage("ShowMessage : OnClickCardBagBtn");
        Debug.Log("OnClickCardBagBtn");
        SceneSwitcher.LoadSceneByIndex(ESceneType.CARDBAGSCENE);
    }
}
