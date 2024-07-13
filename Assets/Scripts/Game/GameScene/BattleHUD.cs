using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleHUD : MonoBehaviour
{
    public Slider hpSlider;

    public Slider mpSlider;

    public GameObject Skill;
    public GameObject Role;
    public void SetHUD(Hero hero)
    {
        hpSlider.maxValue = hero.hp;
        hpSlider.value = hero.hp;
        mpSlider.maxValue = hero.mp;
        mpSlider.value = hero.mp;
    }

    public void SetHP(float hp)
    {
        hpSlider.value = hp;
    }
    public void SetMP(float mp)
    {
        mpSlider.value = mp;
    }
}
