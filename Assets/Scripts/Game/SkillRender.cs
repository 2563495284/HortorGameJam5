using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillRender : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public Text skillName;
    public Button btnSkill;

    public Text skillRound;
    public Text skillMpCost;

    public Image skillMainAttrImg;
    public Image skillSubAttrImg;

    public float longPressThreshold = 0.1f; // 时间阈值（秒）

    public float dragThreshold = 10f;     // 拖动阈值（像素）
    private bool isPointerDown = false;
    private Vector2 initialPointerPosition;
    private float pointerDownTimer = 0f;

    public delegate void ButtonPressHandler();
    private Skill _skill;

    private void Start()
    {


        // // 获取按钮的 EventTrigger 组件，如果不存在则添加它
        // EventTrigger eventTrigger = btnSkill.gameObject.GetComponent<EventTrigger>();
        // if (eventTrigger == null)
        // {
        //     eventTrigger = btnSkill.gameObject.AddComponent<EventTrigger>();
        // }

        // // 创建 PointerDown 事件
        // EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        // pointerDownEntry.eventID = EventTriggerType.PointerDown;
        // pointerDownEntry.callback.AddListener((eventData) => { OnPointerDown((PointerEventData)eventData); });
        // eventTrigger.triggers.Add(pointerDownEntry);

        // // 创建 PointerUp 事件
        // EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        // pointerUpEntry.eventID = EventTriggerType.PointerUp;
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
                    _longClick.Invoke(_skill);
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
                    _shortClick.Invoke(_skill);
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
    private Action<Skill> _shortClick;
    private Action<Skill> _longClick;

    public void OnData(Skill skill, Action<Skill> shortClick = null, Action<Skill> longClick = null)
    {
        _shortClick = shortClick;
        _longClick = longClick;
        _skill = skill;
        if (skill != null)
        {
            skillName.text = skill.name;
            skillMpCost.text = $"{skill.mp}";
            long maxRound = 0;
            skill.mechanics.ForEach(mechanic =>
            {
                if (mechanic.round > maxRound)
                {
                    maxRound = mechanic.round;
                }
            });
            if (maxRound > 0)
            {
                skillRound.text = $"{maxRound}";
            }
            else
            {
                skillRound.text = "0";
            }
        }

        if (skill.attrSummary.Count > 0)
        {
            Sprite mainSprite = ImageLoader.Instance.getSkillAttr(skill.attrSummary[0]);
            if (mainSprite)
            {

                skillMainAttrImg.sprite = mainSprite;
            }
        }

        if (skill.attrSummary.Count > 1)
        {
            Sprite subSprite = ImageLoader.Instance.getSkillAttr(skill.attrSummary[1]);
            if (subSprite)
            {
                skillSubAttrImg.sprite = subSprite;
                var tmpColor = skillSubAttrImg.color;
                tmpColor.a = 255f;
                Debug.Log(tmpColor);
                skillSubAttrImg.color = tmpColor;
            }
        }
    }

}
