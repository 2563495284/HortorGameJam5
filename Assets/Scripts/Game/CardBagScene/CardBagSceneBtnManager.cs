using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBagSceneBtnManager : MonoBehaviour
{

    public Button cardBagBackBtn;
    // Start is called before the first frame update
    void Start()
    {
        cardBagBackBtn.onClick.AddListener(OnClickCardBagBackBtn);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnClickCardBagBackBtn()
    {
        MessageManager.Instance.ShowMessage("ShowMessage : OnClickStartBtn");
        Debug.Log("OnClickStartBtn");
        SceneSwitcher.LoadSceneByIndex(ESceneType.MAINSCENE);
    }

}
