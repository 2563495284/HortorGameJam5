using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleHUD : MonoBehaviour
{
    public Text hpText;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        hpText.text = unit.currentHP.ToString() + "/" + unit.maxHP.ToString();
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
        hpText.text = hp.ToString() + "/" + hpSlider.maxValue.ToString();
    }
}
