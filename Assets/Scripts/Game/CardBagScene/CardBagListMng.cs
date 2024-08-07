using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using System;

public class CardBagListMng : MonoBehaviour
{
    public Transform roleScrollContent; // 这个是Content对象的Transform
    public Transform skillScrollContent; // 这个是Content对象的Transform

    public ObjectPool listItemRoleObjectPool;
    public ObjectPool listItemSkillObjectPool;

    public GameObject Role;//选择的主角
    void Start()
    {
        resetHero();
    }
    void OnDestroy()
    {
    }
    public void resetHero()
    {
        PopulateRoleList();
        PopulateSkillList();
        RefreshRole();
    }
    #region 角色卡牌
    public void PopulateRoleList()
    {
        // Clear existing items (optional)
        foreach (Transform child in roleScrollContent)
        {
            listItemRoleObjectPool.ReturnPooledObject(child.gameObject);
        }
        List<Hero> listHeros = PlayerModel.Instance.role.heros;
        if (listHeros.Count > 0)
        {
            PlayerModel.Instance.setCurtHero(listHeros[0]);
        }
        // Create new items
        for (int i = 0; i < listHeros.Count; i++)
        {
            Hero hero = listHeros[i];
            GameObject listItem = listItemRoleObjectPool.GetPooledObject();
            listItem.transform.SetParent(roleScrollContent);
            listItem.transform.localScale = new Vector3(0.8f, 0.8f, 1);
            listItem.SetActive(true); // 确保模板项是启用状态
            // 设置按钮的文本（你可以根据具体需求进行各种设置）
            RoleRender roleRender = listItem.GetComponentInChildren<RoleRender>();
            roleRender.OnData(hero, onClickRole);

            // 你可以在这里添加任何其他的初始化代码，比如添加事件监听器等
        }
    }
    #endregion

    #region 技能卡牌
    public void PopulateSkillList()
    {
        // Clear existing items (optional)
        foreach (Transform child in skillScrollContent)
        {
            listItemSkillObjectPool.ReturnPooledObject(child.gameObject);
        }
        Hero hero = PlayerModel.Instance.curtHero;
        if (hero == null)
        {
            return;
        }
        if (hero == null) return;
        List<Skill> listSkills = hero.skills;
        Debug.Log(hero.skills.Count);
        // Create new items
        for (int i = 0; i < listSkills.Count; i++)
        {
            Skill skill = listSkills[i];
            GameObject listItem = listItemSkillObjectPool.GetPooledObject();
            listItem.transform.SetParent(skillScrollContent);
            listItem.transform.localScale = new Vector3(0.7f, 0.7f, 1);
            listItem.SetActive(true); // 确保模板项是启用状态
            SkillRender skillRender = listItem.GetComponentInChildren<SkillRender>();
            skillRender.OnData(skill, onClickSkill);

            // 你可以在这里添加任何其他的初始化代码，比如添加事件监听器等
        }
    }
    #endregion
    public void RefreshRole()
    {
        Hero hero = PlayerModel.Instance.curtHero;
        if (hero != null)
        {
            RoleRender roleRender = Role.GetComponentInChildren<RoleRender>();
            roleRender.OnData(hero, onClickRole);
            Role.SetActive(true);
        }
        else
        {
            Role.SetActive(false);
        }

    }
    public void onClickRole(Hero hero)
    {
        PlayerModel.Instance.setCurtHero(hero);
        RefreshRole();
        PopulateSkillList();
    }
    private void onClickSkill(Skill skill)
    {
        SkillInfoView.Instance.ShowSkillInfoView(skill);
    }
}
