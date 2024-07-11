using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Localization.Platform.Android;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class GameSkillPrepareListMng : MonoBehaviour
{
    public Transform skillScrollContent; // 这个是Content对象的Transformm

    public Transform selectedSkillScrollContent;//选择好了的技能列表

    public ObjectPool listItemSkillObjectPool;

    void Start()
    {
        PopulateRoleList();
        PopulateSelectedRoleList();
    }

    public void PopulateRoleList()
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
            Text listItemText = listItem.GetComponentInChildren<Text>();
            if (listItemText != null)
            {
                listItemText.text = skill.name;
            }

        }
    }
    public void PopulateSelectedRoleList()
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
            Text listItemText = listItem.GetComponentInChildren<Text>();
            if (listItemText != null)
            {
                listItemText.text = skill.name;
            }

        }
    }

    public void onClickSkill(Skill skill)
    {
        PlayerModel.Instance.addSkill2List(skill);
        PopulateSelectedRoleList();
    }
    public void onClickSelectedSkill(Skill skill)
    {
        PlayerModel.Instance.removeSkill2List(skill);
        PopulateSelectedRoleList();
    }

}
