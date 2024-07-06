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
    void Start()
    {
        PopulateRoleList();
        PopulateSkillList();

    }

    void PopulateRoleList()
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
            listItem.SetActive(true); // 确保模板项是启用状态

            // 设置按钮的文本（你可以根据具体需求进行各种设置）
            Text listItemText = listItem.GetComponentInChildren<Text>();
            if (listItemText != null)
            {
                listItemText.text = "Item " + (i + 1).ToString();
            }

            // 你可以在这里添加任何其他的初始化代码，比如添加事件监听器等
        }
    }
    void PopulateSkillList()
    {
        // Clear existing items (optional)
        foreach (Transform child in skillScrollContent)
        {
            listItemSkillObjectPool.ReturnPooledObject(child.gameObject);
        }
        if (PlayerModel.Instance.role.heros.Count <= 0) return;
        Hero hero = PlayerModel.Instance.role.heros[0];
        List<Skill> listSkills = hero.skills;
        // Create new items
        for (int i = 0; i < listSkills.Count; i++)
        {
            GameObject listItem = listItemSkillObjectPool.GetPooledObject();
            listItem.SetActive(true); // 确保模板项是启用状态

            // 设置按钮的文本（你可以根据具体需求进行各种设置）
            Text listItemText = listItem.GetComponentInChildren<Text>();
            if (listItemText != null)
            {
                listItemText.text = "Item " + (i + 1).ToString();
            }

            // 你可以在这里添加任何其他的初始化代码，比如添加事件监听器等
        }
    }

}
