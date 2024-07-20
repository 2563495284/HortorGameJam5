using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoleRender : MonoBehaviour
{
    public Button btnRole;

    public Image headImg;

    public Text nameText;

    public Image natureSkillImg;
    public float longPressThreshold = 0.1f; // 时间阈值（秒）

    private Vector2 initialPointerPosition;
    public float dragThreshold = 10f;     // 拖动阈值（像素）

    private bool isPointerDown = false;
    private bool isLongPress = false;
    private float pointerDownTimer = 0;
    private Hero _hero;
    private void Start()
    {
        // // 获取按钮的 EventTrigger 组件，如果不存在则添加它
        // EventTrigger eventTrigger = btnRole.gameObject.GetComponent<EventTrigger>();
        // if (eventTrigger == null)
        // {
        //     eventTrigger = btnRole.gameObject.AddComponent<EventTrigger>();
        // }

        // // 创建 PointerDown 事件
        // EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        // pointerDownEntry.eventID = EventTriggerType.PointerDown;
        // pointerDownEntry.callback.AddListener((eventData) => { OnPointerDown((PointerEventData)eventData); });
        // eventTrigger.triggers.Add(pointerDownEntry);

        // // 创建 PointerUp 事件
        // EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        // pointerUpEntry.eventID = EventTriggerType.PointerClick;
        // pointerUpEntry.callback.AddListener((eventData) => { OnPointerUp((PointerEventData)eventData); });
        // eventTrigger.triggers.Add(pointerUpEntry);

        // EventTrigger.Entry pointerCancel = new EventTrigger.Entry();
        // pointerCancel.eventID = EventTriggerType.Cancel;
        // pointerCancel.callback.AddListener((eventData) => { OnPointerCancel((PointerEventData)eventData); });
        // eventTrigger.triggers.Add(pointerCancel);
    }
    private void Update()
    {
        if (isPointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= longPressThreshold)
            {
                // 成功触发长按
                if (_longClick != null)
                {
                    _longClick.Invoke(_hero);
                }
                Reset();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        pointerDownTimer = 0f;
        initialPointerPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isPointerDown)
        {
            float distance = Vector2.Distance(initialPointerPosition, eventData.position);
            if (pointerDownTimer < longPressThreshold && distance < dragThreshold)
            {
                // 成功触发短按
                if (_shortClick != null)
                {
                    _shortClick.Invoke(_hero);
                }
            }
        }
        Reset();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Reset();
    }

    private void Reset()
    {
        isPointerDown = false;
        pointerDownTimer = 0f;
    }
    private Action<Hero> _shortClick;
    private Action<Hero> _longClick;
    public void OnData(Hero hero, Action<Hero> shortClick = null, Action<Hero> longClick = null)
    {
        _shortClick = shortClick;
        _longClick = longClick;
        _hero = hero;
        if (hero != null)
        {
            nameText.text = hero.name;
            if (headImg != null && hero.avatar != null)
            {
                Debug.LogWarning("<<<<avatar<<<<" + hero.avatar);
                byte[] imageBytes = Convert.FromBase64String(hero.avatar);
                Debug.Log("宽:" + headImg.rectTransform.rect.width + "高：" + headImg.rectTransform.rect.height);
                Texture2D tex = new Texture2D((int)headImg.rectTransform.rect.width, (int)headImg.rectTransform.rect.height);
                tex.LoadImage(imageBytes);
                headImg.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            }
            Sprite natureSprite = ImageLoader.Instance.getSkillAttr(hero.talent.attr);
            if (natureSprite != null)
            {
                natureSkillImg.sprite = natureSprite;
            }
            else
            {
                natureSkillImg.sprite = null;
            }
        }
    }
}
