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
    public void refreshHeroState(BattleHero battleHero)
    {
        hpSlider.maxValue = battleHero.maxHp;
        hpSlider.value = battleHero.hp;
        mpSlider.maxValue = battleHero.maxMp;
        mpSlider.value = battleHero.mp;
    }

}
