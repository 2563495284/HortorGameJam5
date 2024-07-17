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

    public Text hpText;

    public Text mpText;

    public Text roleText;

    private EBattleHeroType _battleHeroType;
    private BattleHeroInfo battleHeroInfo
    {
        get
        {
            return BattleManager.Instance.getBattleHeroInfo(_battleHeroType);
        }
    }
    public void init(EBattleHeroType battleHeroType)
    {
        _battleHeroType = battleHeroType;
        roleText.text = battleHeroInfo.heroName;
        hpText.text = $"hp:{battleHeroInfo.hp}/{battleHeroInfo.maxHp}";
        hpSlider.maxValue = battleHeroInfo.maxHp;
        hpSlider.value = battleHeroInfo.hp;
        mpText.text = $"mp:{battleHeroInfo.mp}/{battleHeroInfo.maxMp}";
        mpSlider.maxValue = battleHeroInfo.maxMp;
        mpSlider.value = battleHeroInfo.mp;
    }
    public void CheckHeroStateChange(RoundState roundState)
    {
        // if (roundState.hp > 0)
        // {
        // }
        // else if (roundState.hp < 0)
        // {
        // }
        if (roundState.hp != 0)
        {
            hpSlider.DOValue(battleHeroInfo.hp + roundState.hp, 0.5f, true).OnUpdate(UpdateHpText);
        }


        // if (roundState.mp > 0)
        // {
        //     mpSlider.DOValue(roundState.mp + battleHeroInfo.mp, 0.5f, true);
        // }
        // else if (roundState.mp < 0)
        // {
        // }
        if (roundState.mp != 0)
        {
            mpSlider.DOValue(battleHeroInfo.mp + roundState.mp, 0.5f, true).OnComplete(UpdateMpText);
        }
    }
    public async UniTask playHeroStateChange()
    {

        await UniTask.Delay(500);
    }
    void UpdateHpText()
    {
        hpText.text = $"hp:{hpSlider.value}/{battleHeroInfo.maxHp}";
    }
    void UpdateMpText()
    {
        mpText.text = $"hp:{mpSlider.value}/{battleHeroInfo.maxMp}";
    }

}
