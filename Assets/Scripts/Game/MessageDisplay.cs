using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance { get; private set; }
    public GameObject tips;
    public GameObject messagePanel; // ����UI���
    public Text messageText;        // ����Text���

    private void Awake()
    {
        // ȷ��ֻ��һ��ʵ������
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ��ֹ�ڼ����³���ʱ���ٶ���
        }
        else
        {
            Destroy(gameObject);
        }
        DOTween.Init(true, true);
    }

    private void Start()
    {
        HideMessage();
    }

    public void ShowMessage(string str)
    {
        messageText.text = str;
        Color initialTextColor = messageText.color;
        initialTextColor.a = 0f;
        tips.SetActive(true);
        messageText.DOFade(1f, 0.3f).OnComplete(() =>
        {
            Invoke("HideMessage", 2);
        });
    }

    public void HideMessage()
    {

        tips.SetActive(false);
    }
}