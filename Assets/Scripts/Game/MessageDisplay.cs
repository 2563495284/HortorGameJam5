using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance { get; private set; }
    public GameObject tips;
    public GameObject messagePanel; // 引用UI面板
    public Text messageText;        // 引用Text组件

    private void Awake()
    {
        // 确保只有一个实例存在
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 防止在加载新场景时销毁对象
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