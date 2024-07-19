using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroAttrRender : MonoBehaviour
{
    public Text attrName;

    public Text attrDesc;

    public void OnData(string attrName, float attrDesc)
    {
        switch (attrName)
        {
            case EHeroAttr.Hp:
                attrName = "生命值";
                break;
            case EHeroAttr.Mp:
                attrName = "魔法值";
                break;
            case EHeroAttr.WeaponDamage:
                attrName = "武器伤害";
                break;
        }
        this.attrName.text = attrName;
        this.attrDesc.text = $"{attrName}:{attrDesc}";
    }
}
