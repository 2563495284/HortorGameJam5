using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Utils;
public enum EBattleSkillEffectType
{
    maxHp,
    hp,
    maxMp,
    mp,
    weaponDamage,
    armor,
    critRate,
    dodge,
    stun,
    comb,
    fireCrit,
    fireDodge,
    fireStun,
    fireComb,
}
public class BattleHUD : MonoBehaviour
{
    public Slider hpSlider;

    public Slider mpSlider;
    public GameObject role;

    public Text hpText;

    public Text mpText;

    public Text roleText;

    private EBattleHeroType _battleHeroType;

    public List<EBattleSkillEffectType> battleSkillEffectTypeList = new List<EBattleSkillEffectType>();

    private bool _isStun;
    public ParticleSystem hpLoseEffect;

    public ParticleSystem healthEffect;

    public ParticleSystem mpEffect;
    public ParticleSystem stunEffect;

    public ParticleSystem weaponDamageEffect;

    public ParticleSystem armorEffect;
    private BattleHeroInfo battleHeroInfo
    {
        get
        {
            return BattleManager.Instance.getBattleHeroInfo(_battleHeroType);
        }
    }
    public Vector3 GetHeroPos()
    {
        return role.transform.position;
    }
    public RectTransform GetHeroRectTransform()
    {

        RectTransform rectTransform = role.GetComponent<RectTransform>();
        return rectTransform;
    }
    public float GetHeroHeight()
    {
        RectTransform rectTransform = role.GetComponent<RectTransform>();
        return rectTransform.rect.height * role.transform.localScale.y;
    }
    private void Start()
    {
        hpLoseEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        healthEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        mpEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        stunEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        weaponDamageEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        armorEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
    public void init(EBattleHeroType battleHeroType)
    {
        RoleRender roleRender = role.GetComponent<RoleRender>();
        _battleHeroType = battleHeroType;
        roleRender.OnData(HeroAdaptor.transformBattleHeroResp(battleHeroInfo.hero), onClickRole);
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
        battleSkillEffectTypeList.Clear();

        if (roundState.maxHp != 0)
        {
            battleSkillEffectTypeList.Add(EBattleSkillEffectType.maxHp);
        }
        if (roundState.hp != 0)
        {
            battleSkillEffectTypeList.Add(EBattleSkillEffectType.hp);
        }
        if (roundState.maxMp != 0)
        {
            battleSkillEffectTypeList.Add(EBattleSkillEffectType.maxMp);
        }
        if (roundState.mp != 0)
        {
            battleSkillEffectTypeList.Add(EBattleSkillEffectType.mp);
        }
        if (roundState.weaponDamage != 0)
        {
            battleSkillEffectTypeList.Add(EBattleSkillEffectType.weaponDamage);
        }
        if (roundState.armor != 0)
        {
            battleSkillEffectTypeList.Add(EBattleSkillEffectType.armor);
        }
        if (roundState.fireCrit)
        {
            battleSkillEffectTypeList.Add(EBattleSkillEffectType.fireCrit);
        }
        if (roundState.fireDodge)
        {
            battleSkillEffectTypeList.Add(EBattleSkillEffectType.fireDodge);
        }
        if (roundState.fireStun)
        {
            battleSkillEffectTypeList.Add(EBattleSkillEffectType.fireStun);
        }
        if (roundState.fireComb)
        {
            battleSkillEffectTypeList.Add(EBattleSkillEffectType.fireComb);
        }


    }
    public async UniTask playHeroStateChange(RoundState roundState)
    {
        _isStun = false;
        battleSkillEffectTypeList.ForEach(battleSkillEffectType =>
        {
            switch (battleSkillEffectType)
            {
                case EBattleSkillEffectType.maxHp:
                    if (roundState.maxHp != 0)
                    {
                        battleHeroInfo.maxHp += roundState.maxHp;
                        hpSlider.maxValue = battleHeroInfo.maxHp;
                        UpdateHpText();
                    }
                    break;
                case EBattleSkillEffectType.hp:
                    if (roundState.hp != 0)
                    {
                        hpSlider.DOValue(battleHeroInfo.hp + roundState.hp, 0.5f, true).OnUpdate(UpdateHpText);
                        battleHeroInfo.hp += roundState.hp;
                    }
                    if (roundState.hp < 0)
                    {
                        hpLoseEffect.Play();
                    }
                    else if (roundState.hp > 0)
                    {
                        healthEffect.Play();
                    }
                    break;
                case EBattleSkillEffectType.maxMp:
                    if (roundState.maxMp != 0)
                    {
                        battleHeroInfo.maxMp += roundState.maxMp;
                        mpSlider.maxValue = battleHeroInfo.maxMp;
                        UpdateMpText();
                    }
                    break;
                case EBattleSkillEffectType.mp:
                    if (roundState.mp != 0)
                    {
                        mpSlider.DOValue(battleHeroInfo.mp + roundState.mp, 0.5f, true).OnComplete(UpdateMpText);
                        battleHeroInfo.mp += roundState.mp;
                    }
                    if (roundState.mp > 0)
                    {
                        mpEffect.Play();
                    }
                    break;
                case EBattleSkillEffectType.weaponDamage:
                    if (roundState.weaponDamage > 0)
                    {
                        weaponDamageEffect.Play();
                    }
                    break;
                case EBattleSkillEffectType.armor:
                    if (roundState.armor > 0)
                    {
                        armorEffect.Play();
                    }
                    break;
                case EBattleSkillEffectType.critRate: break;
                case EBattleSkillEffectType.dodge: break;
                case EBattleSkillEffectType.stun: break;
                case EBattleSkillEffectType.comb: break;
                case EBattleSkillEffectType.fireCrit: break;
                case EBattleSkillEffectType.fireDodge: break;
                case EBattleSkillEffectType.fireStun: break;
                case EBattleSkillEffectType.fireComb: break;

            }
        });
        if (_isStun)
        {
            stunEffect.Play();
        }
        else
        {
            stunEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        await UniTask.Delay(500);
    }
    void UpdateHpText()
    {
        hpText.text = $"hp:{hpSlider.value}/{battleHeroInfo.maxHp}";
    }
    void UpdateMpText()
    {
        mpText.text = $"mp:{mpSlider.value}/{battleHeroInfo.maxMp}";
    }
    private void onClickRole(Hero hero)
    {

        HeroInfoView.Instance.ShowHeroInfoView(hero);
    }
}
