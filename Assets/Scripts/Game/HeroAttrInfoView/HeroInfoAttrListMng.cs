using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public static class EHeroAttr
{
    public const string Hp = "Hp";
    public const string Mp = "Mp";
    public const string WeaponDamage = "WeaponDamage";
    public const string Armor = "Armor";
    public const string CritRate = "CritRate";
    public const string Dodge = "Dodge";
    public const string Stun = "Stun";
    public const string Comb = "Comb";
    public const string Round = "Round";
    public const string MaxHp = "MaxHp";
    public const string MaxMp = "MaxMp";
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

    public void PopulateHeroAttrList(Hero hero)
    {
        // Clear existing items (optional)
        foreach (Transform child in heroAttrScrollContent)
        {
            listItemHeroAttrObjectPool.ReturnPooledObject(child.gameObject);
        }
        if (hero == null) return;
        // Create new items
        List<SHeroAttr> heroAttrs = new List<SHeroAttr>();
        heroAttrs.Add(new SHeroAttr() { heroAttr = EHeroAttr.Hp, val = hero.hp });
        heroAttrs.Add(new SHeroAttr() { heroAttr = EHeroAttr.Mp, val = hero.mp });
        heroAttrs.Add(new SHeroAttr() { heroAttr = EHeroAttr.WeaponDamage, val = hero.weaponDamage });
        for (int i = 0; i < heroAttrs.Count; i++)
        {
            SHeroAttr heroAttr = heroAttrs[i];
            GameObject listItem = listItemHeroAttrObjectPool.GetPooledObject();
            listItem.transform.SetParent(heroAttrScrollContent);
            listItem.transform.localScale = new Vector3(1, 1, 1);
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
