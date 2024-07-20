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
    public float requiredHoldTime = 0.3f; // 长按所需时间

    private bool isPointerDown = false;
    private bool isLongPress = false;
    private float pointerDownTimer = 0;
    private Hero _hero;
    private void Start()
    {
        // 获取按钮的 EventTrigger 组件，如果不存在则添加它
        EventTrigger eventTrigger = btnRole.gameObject.GetComponent<EventTrigger>();
        if (eventTrigger == null)
        {
            eventTrigger = btnRole.gameObject.AddComponent<EventTrigger>();
        }

        // 创建 PointerDown 事件
        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((eventData) => { OnPointerDown((PointerEventData)eventData); });
        eventTrigger.triggers.Add(pointerDownEntry);

        // 创建 PointerUp 事件
        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerClick;
        pointerUpEntry.callback.AddListener((eventData) => { OnPointerUp((PointerEventData)eventData); });
        eventTrigger.triggers.Add(pointerUpEntry);

        EventTrigger.Entry pointerCancel = new EventTrigger.Entry();
        pointerCancel.eventID = EventTriggerType.Cancel;
        pointerCancel.callback.AddListener((eventData) => { OnPointerCancel((PointerEventData)eventData); });
        eventTrigger.triggers.Add(pointerCancel);
    }
    void Update()
    {
        if (isPointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (!isLongPress)
                {
                    isLongPress = true;
                    OnLongPress();
                }
            }
        }
    }
    private void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        pointerDownTimer = 0;
        isLongPress = false;
    }

    private void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        if (!isLongPress)
        {
            OnShortPress();
        }
    }
    private void OnPointerCancel(PointerEventData eventData)
    {
        isPointerDown = false;
        pointerDownTimer = 0;
        isLongPress = false;
    }


    private void OnLongPress()
    {
        // 在这里添加长按事件处理逻辑
        if (_hero == null) return;
        Debug.Log("Long Press Triggered!");
        if (_longClick != null)
        {
            _longClick.Invoke(_hero);
        }
    }

    private void OnShortPress()
    {
        // 在这里添加短按事件处理逻辑
        if (_hero == null) return;
        Debug.Log("Short Press Triggered!");
        if (_shortClick != null)
        {
            _shortClick.Invoke(_hero);
        }
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
