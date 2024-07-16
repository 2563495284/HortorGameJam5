using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class BattleHUD : MonoBehaviour
{
    public Slider hpSlider;

    public Slider mpSlider;
    public GameObject role;

    private BattleHero _battleHero;

    public Text hpText;

    public Text mpText;

    public Text roleText;
    public void init(Hero hero)
    {
        roleText.text = hero.name;
    }
    public void refreshHeroState(BattleHero battleHero)
    {
        hpText.text = $"hp:{battleHero.hp}/{battleHero.maxHp}";
        hpSlider.maxValue = battleHero.maxHp;
        hpSlider.value = battleHero.hp;
        mpText.text = $"mp:{battleHero.mp}/{battleHero.maxMp}";
        mpSlider.maxValue = battleHero.maxMp;
        mpSlider.value = battleHero.mp;
        _battleHero = battleHero;
    }
    public async UniTask playHeroStateChange(RoundState roundState)
    {
        if (roundState.hp > 0)
        {
            hpSlider.DOValue(roundState.hp + _battleHero.hp, 0.5f, true);
        }
        else if (roundState.hp < 0)
        {
            hpSlider.DOValue(_battleHero.hp + roundState.hp, 0.5f, true);
        }


        if (roundState.mp > 0)
        {
            mpSlider.DOValue(roundState.mp + _battleHero.mp, 0.5f, true);
        }
        else if (roundState.mp < 0)
        {
            mpSlider.DOValue(_battleHero.mp + roundState.mp, 0.5f, true);
        }

        // Text hpText = hpSlider.GetComponentInChildren<Text>();
        // hpSlider.DOValue(roundState.hp, 0.5f, true).OnUpdate(() =>
        // {
        //     // hpText.text = $"hp:{hpSlider.value}/{hpSlider.maxValue}";
        // });

        // Text mpText = mpSlider.GetComponentInChildren<Text>();
        // mpSlider.DOValue(roundState.mp, 0.5f, true).OnUpdate(() =>
        // {
        //     // mpText.text = $"hp:{mpSlider.value}/{mpSlider.maxValue}";
        // }).OnComplete(() =>
        // {
        // });
        await UniTask.Delay(500);
    }
    private void OnHealthUpdated()
    {

    }
    private void OnMpUpdated()
    {
        hpText.text = $"hp:{_battleHero.hp}/{_battleHero.maxHp}";
        mpText.text = $"mp:{_battleHero.mp}/{_battleHero.maxMp}";
    }

}
