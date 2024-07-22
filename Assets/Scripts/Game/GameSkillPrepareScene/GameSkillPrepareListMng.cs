using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using DG.Tweening;
using UnityEditor.VersionControl;
public class GameSkillPrepareListMng : MonoBehaviour
{
    public Transform skillScrollContent; // 这个是Content对象的Transformm

    public Transform selectedSkillScrollContent;//选择好了的技能列表

    public ObjectPool listItemSkillObjectPool;

    public ScrollRect scrollRect;
    void Start()
    {
        PlayerModel.Instance.initHeroAttrList();
        PopulateSkillList();
        PopulateSelectedSkillList();

    }
    private void OnDestroy()
    {
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
            listItem.transform.localScale = new Vector3(0.7f, 0.7f, 1);
            listItem.SetActive(true); // 确保模板项是启用状态
            // 设置按钮的文本（你可以根据具体需求进行各种设置）
            SkillRender skillRender = listItem.GetComponentInChildren<SkillRender>();
            if (skillRender != null)
            {
                skillRender.OnData(skill, onClickSkill, onClickSkillShowInfo);
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
            listItem.transform.localScale = new Vector3(0.7f, 0.7f, 1);

            listItem.SetActive(true); // 确保模板项是启用状态
            // 设置按钮的文本（你可以根据具体需求进行各种设置）
            SkillRender skillRender = listItem.GetComponentInChildren<SkillRender>();
            if (skillRender != null)
            {
                skillRender.OnData(skill, onClickSeleCtedSkill);
            }

        }
    }

    public void onClickSkill(Skill skill)
    {
        if (PlayerModel.Instance.getSkillCount() >= 8)
        {
            MessageManager.Instance.ShowMessage("上阵技能数量已满，无法再添加技能");
            return;
        }
        PlayerModel.Instance.addSkill2List(skill);
        PopulateSelectedSkillList();
        scrollRect.DOHorizontalNormalizedPos(1f, 0.5f);
    }
    public void onClickSeleCtedSkill(Skill skill)
    {
        PlayerModel.Instance.removeSkill2List(skill);
        PopulateSelectedSkillList();

    }
    public void onClickSkillShowInfo(Skill skill)
    {
        SkillInfoView.Instance.ShowSkillInfoView(skill);
    }
}
