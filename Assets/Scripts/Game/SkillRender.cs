using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillRender : MonoBehaviour
{
    public Text skillName;
    public Button btnSkill;

    public Text skillRound;
    public Text skillMpCost;

    public Image skillMainAttrImg;
    public Image skillSubAttrImg;

    public float requiredHoldTime = 0.6f; // 长按所需时间

    private bool isPointerDown = false;
    private bool isLongPress = false;
    private float pointerDownTimer = 0;
    private Skill _skill;

    private void Start()
    {

        // 添加事件监听器
        btnSkill.onClick.AddListener(OnShortPressWrapper);

        // 获取按钮的 EventTrigger 组件，如果不存在则添加它
        EventTrigger eventTrigger = btnSkill.gameObject.GetComponent<EventTrigger>();
        if (eventTrigger == null)
        {
            eventTrigger = btnSkill.gameObject.AddComponent<EventTrigger>();
        }

        // 创建 PointerDown 事件
        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((eventData) => { OnPointerDown((PointerEventData)eventData); });
        eventTrigger.triggers.Add(pointerDownEntry);

        // 创建 PointerUp 事件
        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerUp;
        pointerUpEntry.callback.AddListener((eventData) => { OnPointerUp((PointerEventData)eventData); });
        eventTrigger.triggers.Add(pointerUpEntry);
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
            btnSkill.onClick.Invoke();
        }
    }

    private void OnLongPress()
    {
        Debug.Log("Long Press Triggered!");
        // 在这里添加长按事件处理逻辑
        if (_skill == null) return;
        PlayerModel.Instance.e.TriggerEvent(EGameEvent.LONG_CLICK_SKILL, _skill);
    }

    private void OnShortPressWrapper()
    {
        if (!isLongPress) // 确保事件只在短按时触发
        {
            OnShortPress();
        }
    }

    private void OnShortPress()
    {
        Debug.Log("Short Press Triggered!");
        // 在这里添加短按事件处理逻辑
        if (_skill == null) return;
        PlayerModel.Instance.e.TriggerEvent(EGameEvent.SHORT_CLICK_SKILL, _skill);
    }
    public void OnData(Skill skill)
    {
        _skill = skill;
        if (skill != null)
        {
            skillName.text = skill.name;
            skillMpCost.text = $"{skill.mp}";
            long maxRound = 0;
            skill.mechanics.ForEach(mechanic => { if (mechanic.round > maxRound) { maxRound = mechanic.round; } });
            if (maxRound > 0)
            {
                skillRound.text = $"{maxRound}";
            }
            else
            {
                skillRound.text = "0";
            }
        }
        if (skill.attrSummary.Count >= 2)
        {
            Sprite mainSprite = ImageLoader.Instance.getSkillAttr(skill.attrSummary[0]);
            Sprite subSprite = ImageLoader.Instance.getSkillAttr(skill.attrSummary[1]);
            if (mainSprite)
            {

                skillMainAttrImg.sprite = mainSprite;
            }
            if (subSprite)
            {
                skillSubAttrImg.sprite = subSprite;
            }
        }
    }
}
