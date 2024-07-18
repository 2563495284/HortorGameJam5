using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class CardBagListMng : MonoBehaviour
{
    public Transform roleScrollContent; // 这个是Content对象的Transform
    public Transform skillScrollContent; // 这个是Content对象的Transform

    public ObjectPool listItemRoleObjectPool;
    public ObjectPool listItemSkillObjectPool;

    public GameObject Role;//选择的主角
    void Start()
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
        // Create new items
        for (int i = 0; i < listHeros.Count; i++)
        {
            Hero hero = listHeros[i];
            GameObject listItem = listItemRoleObjectPool.GetPooledObject();
            listItem.transform.SetParent(roleScrollContent);
            listItem.SetActive(true); // 确保模板项是启用状态
            Button btn = listItem.GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => { onClickRole(hero); });
            // 设置按钮的文本（你可以根据具体需求进行各种设置）
            Text listItemText = listItem.GetComponentInChildren<Text>();
            Image image = listItem.GetComponent<Image>();
            if (listItemText != null)
            {
                listItemText.text = hero.name;
            }

            // 你可以在这里添加任何其他的初始化代码，比如添加事件监听器等
        }
    }
    public void onClickRole(Hero hero)
    {
        PlayerModel.Instance.setCurtHero(hero);
        RefreshRole();
        PopulateSkillList();
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
        if (hero == null) return;
        List<Skill> listSkills = hero.skills;
        Debug.Log(hero.skills.Count);
        // Create new items
        for (int i = 0; i < listSkills.Count; i++)
        {
            Skill skill = listSkills[i];
            GameObject listItem = listItemSkillObjectPool.GetPooledObject();
            listItem.transform.SetParent(skillScrollContent);
            listItem.SetActive(true); // 确保模板项是启用状态

            // 设置按钮的文本（你可以根据具体需求进行各种设置）
            Text listItemText = listItem.GetComponentInChildren<Text>();
            if (listItemText != null)
            {
                listItemText.text = skill.name;
            }

            // 你可以在这里添加任何其他的初始化代码，比如添加事件监听器等
        }
    }
    #endregion
    public void RefreshRole()
    {
        Hero hero = PlayerModel.Instance.curtHero;
        Text RoleText = Role.GetComponentInChildren<Text>();
        RoleText.text = hero.name;
    }

}
