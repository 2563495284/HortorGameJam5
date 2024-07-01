using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Card;
public class BattleHUD : MonoBehaviour
{
    public Text hpText;
    public Slider hpSlider;

    public void SetHUD(RoleCard card)
    {
        hpSlider.maxValue = card.maxHp;
        hpSlider.value = card.hp;
        hpText.text = card.hp.ToString() + "/" + card.maxHp.ToString();
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
        hpText.text = hp.ToString() + "/" + hpSlider.maxValue.ToString();
    }
}
