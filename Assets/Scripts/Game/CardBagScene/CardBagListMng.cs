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
            Image avatar = listItem.transform.Find("HeadImg").GetComponentInChildren<Image>();
            if (avatar != null && hero.avatar != null)
            {
                Debug.LogWarning("<<<<avatar<<<<" + hero.avatar);
                byte[] imageBytes = Convert.FromBase64String(hero.avatar);
                Debug.Log("宽:" + avatar.rectTransform.rect.width + "高：" + avatar.rectTransform.rect.height);
                Texture2D tex = new Texture2D((int)avatar.rectTransform.rect.width, (int)avatar.rectTransform.rect.height);
                tex.LoadImage(imageBytes);
                avatar.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            }
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
        if (hero != null)
        {
            Text RoleText = Role.GetComponentInChildren<Text>();
            RoleText.text = hero.name;
            Role.SetActive(true);
        }
        else
        {
            Role.SetActive(false);
        }

    }

}
