using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MessageManager : Singleton<MessageManager>
{
    public Text messageText;
    public GameObject messagePanel;
    public float displayDuration = 2f;

    private float displayTimer;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        GameObject messagePanelPrefab = Resources.Load<GameObject>("Prefabs/MessageManager");
        if (messagePanelPrefab)
        {
            messagePanel = Instantiate(messagePanelPrefab);
            messagePanel.transform.SetParent(this.gameObject.transform);
            messagePanel.SetActive(false);

            messageText = messagePanel.GetComponentInChildren<Text>();
            messageText.DOFade(0f, 0f);

        }
        else
        {
            Debug.LogError("messagePanel is null");
        }
    }



    public void ShowMessage(string message)
    {
        if (messageText && messagePanel)
        {
            messageText.text = message;
            messagePanel.SetActive(true);
            displayTimer = displayDuration;
            messageText.DOFade(1f, 0.3f).OnComplete(() =>
            {
                Invoke("HideMessage", 2);
            });
        }
    }
    private void HideMessage()
    {
        if (messagePanel)
        {
            messageText.DOFade(0f, 0.3f).OnComplete(() =>
            {
                messagePanel.SetActive(false);
            });
        }
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}