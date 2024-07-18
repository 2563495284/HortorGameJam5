using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
public class GameSkillPrepareListMng : MonoBehaviour
{
    public Transform skillScrollContent; // 这个是Content对象的Transformm

    public Transform selectedSkillScrollContent;//选择好了的技能列表

    public ObjectPool listItemSkillObjectPool;

    void Start()
    {
        PlayerModel.Instance.initSkillList();
        PopulateSkillList();
        PopulateSelectedSkillList();
    }

    public void PopulateSkillList()
    {
        // Clear existing items (optional)
        foreach (Transform child in skillScrollContent)
        {
            listItemSkillObjectPool.ReturnPooledObject(child.gameObject);
        }
        List<Skill> listSkills = PlayerModel.Instance.curtHero.skills;
        // Create new items
        for (int i = 0; i < listSkills.Count; i++)
        {
            Skill skill = listSkills[i];
            GameObject listItem = listItemSkillObjectPool.GetPooledObject();
            listItem.transform.SetParent(skillScrollContent);
            listItem.SetActive(true); // 确保模板项是启用状态
            Button btn = listItem.GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => { onClickSkill(skill); });
            // 设置按钮的文本（你可以根据具体需求进行各种设置）
            SkillRender skillRender = listItem.GetComponentInChildren<SkillRender>();
            if (skillRender != null)
            {
                skillRender.OnData(skill);
            }

        }
    }
    public void PopulateSelectedSkillList()
    {
        // Clear existing items (optional)
        foreach (Transform child in selectedSkillScrollContent)
        {
            listItemSkillObjectPool.ReturnPooledObject(child.gameObject);
        }
        List<Skill> listSkills = PlayerModel.Instance.skillList;
        // Create new items
        for (int i = 0; i < listSkills.Count; i++)
        {
            Skill skill = listSkills[i];
            GameObject listItem = listItemSkillObjectPool.GetPooledObject();
            listItem.transform.SetParent(selectedSkillScrollContent);
            listItem.SetActive(true); // 确保模板项是启用状态
            Button btn = listItem.GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => { onClickSelectedSkill(skill); });
            // 设置按钮的文本（你可以根据具体需求进行各种设置）
            SkillRender skillRender = listItem.GetComponentInChildren<SkillRender>();
            if (skillRender != null)
            {
                skillRender.OnData(skill);
            }

        }
    }

    public void onClickSkill(Skill skill)
    {
        PlayerModel.Instance.addSkill2List(skill);
        PopulateSelectedSkillList();
    }
    public void onClickSelectedSkill(Skill skill)
    {
        PlayerModel.Instance.removeSkill2List(skill);
        PopulateSelectedSkillList();
    }

}
