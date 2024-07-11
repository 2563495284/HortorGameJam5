using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleHUD : MonoBehaviour
{
    public Text hpText;
    public Slider hpSlider;

    public void SetHUD(Hero hero)
    {
        hpSlider.maxValue = hero.hp;
        hpSlider.value = hero.hp;
        hpText.text = hero.hp.ToString() + "/" + hero.hp.ToString();
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
        hpText.text = hp.ToString() + "/" + hpSlider.maxValue.ToString();
    }
}
