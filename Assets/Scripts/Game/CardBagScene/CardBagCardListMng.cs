using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBagCardListMng : MonoBehaviour
{
    public GameObject listItemTemplate; // 这个是你的列表项模板
    public Transform content; // 这个是Content对象的Transform
    public int listLength = 10; // 这是你想要的列表项数目

    void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        // Clear existing items (optional)
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        // Create new items
        for (int i = 0; i < listLength; i++)
        {
            GameObject listItem = Instantiate(listItemTemplate, content);
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
