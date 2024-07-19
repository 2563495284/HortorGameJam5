using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public static class EHeroAttr
{
    public const string hp = "生命值";
    public const string mp = "魔法值";
    public const string weaponDamage = "武器伤害";
}

public struct SHeroAttr
{
    public string heroAttr;
    public float val;
}
public class HeroInfoAttrListMng : MonoBehaviour
{
    public Transform heroAttrScrollContent; // 这个是Content对象的Transformm

    public ObjectPool listItemHeroAttrObjectPool;

    public Button btnClose;
    void Start()
    {
        btnClose.onClick.AddListener(OnClickBtnClose);
    }

    public void PopulateHeroAttrList()
    {
        // Clear existing items (optional)
        foreach (Transform child in heroAttrScrollContent)
        {
            listItemHeroAttrObjectPool.ReturnPooledObject(child.gameObject);
        }
        Hero hero = PlayerModel.Instance.curtHero;
        if (hero == null) return;
        // Create new items
        List<SHeroAttr> heroAttrs = new List<SHeroAttr>();
        heroAttrs.Add(new SHeroAttr() { heroAttr = EHeroAttr.hp, val = hero.hp });
        heroAttrs.Add(new SHeroAttr() { heroAttr = EHeroAttr.mp, val = hero.mp });
        heroAttrs.Add(new SHeroAttr() { heroAttr = EHeroAttr.weaponDamage, val = hero.weaponDamage });
        for (int i = 0; i < heroAttrs.Count; i++)
        {
            SHeroAttr heroAttr = heroAttrs[i];
            GameObject listItem = listItemHeroAttrObjectPool.GetPooledObject();
            listItem.transform.localScale = new Vector3(1, 1, 1);
            listItem.transform.SetParent(heroAttrScrollContent);
            listItem.SetActive(true); // 确保模板项是启用状态
            // 设置按钮的文本（你可以根据具体需求进行各种设置）
            HeroAttrRender heroAttrRender = listItem.GetComponentInChildren<HeroAttrRender>();
            if (heroAttrRender != null)
            {
                heroAttrRender.OnData(heroAttr.heroAttr, heroAttr.val);
            }

        }
    }
    private void OnClickBtnClose()
    {
        HeroInfoView.Instance.HideHeroInfoView();
    }
}
