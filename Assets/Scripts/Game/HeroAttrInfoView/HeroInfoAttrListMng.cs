using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public static class EHeroAttr
{
    public const string Hp = "hp";
    public const string Mp = "mp";
    public const string WeaponDamage = "weaponDamage";
    public const string Armor = "armor";
    public const string CritRate = "critRate";
    public const string Dodge = "dodge";
    public const string Stun = "stun";
    public const string Comb = "comb";
    public const string Round = "round";
    public const string MaxHp = "maxHp";
    public const string MaxMp = "maxMp";

    public static string Name(string attr)
    {
        switch (attr)
        {
            case EHeroAttr.Hp:
                return "生命值";
            case EHeroAttr.Mp:
                return "魔法值";
            case EHeroAttr.WeaponDamage:
                return "武器伤害";
            case EHeroAttr.Armor:
                return "护甲";
            case EHeroAttr.CritRate:
                return "暴击";
            case EHeroAttr.Dodge:
                return "闪避";
            case EHeroAttr.Stun:
                return "眩晕";
            case EHeroAttr.Comb:
                return "连击";
        }
        return attr;
    }
}



public struct SHeroAttr
{
    public string heroAttr;
    public string val;
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
        heroAttrs.Add(new SHeroAttr() { heroAttr = EHeroAttr.Hp, val = hero.hp.ToString() });
        heroAttrs.Add(new SHeroAttr() { heroAttr = EHeroAttr.Mp, val = hero.mp.ToString() });
        heroAttrs.Add(new SHeroAttr() { heroAttr = EHeroAttr.WeaponDamage, val = hero.weaponDamage.ToString() });
        heroAttrs.Add(new SHeroAttr(){ heroAttr = "天赋", val=$"{EHeroAttr.Name(hero.talent.attr)}  {hero.talent.value}"});
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
