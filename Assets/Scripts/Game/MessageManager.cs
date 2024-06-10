using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance { get; private set; }
    public Text messageText;
    public GameObject messagePanel;
    public float displayDuration = 2f;

    private float displayTimer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ��֤���л�����ʱ���󲻻ᱻ����
        }
        else
        {
            Destroy(gameObject); // �Ѿ�����һ��ʵ���������´�����ʵ��
        }
    }

    private void Start()
    {
        messageText.DOFade(0f, 0f);
        messagePanel.SetActive(false);
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
}