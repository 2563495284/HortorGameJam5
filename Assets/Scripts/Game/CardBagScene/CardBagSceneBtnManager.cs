using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Hortor.O4e.Rpc;
using UnityEngine;
using UnityEngine.UI;


public class CardBagSceneBtnManager : MonoBehaviour
{

    public Button btnCardBagBack;

    public Button btnShowCreateRole;
    public Button btnShowCreateSkill;
    public Button btnSkillScrollView;
    public Button btnDeleteHero;

    #region 角色创建界面
    public Button btnCreateRoleClose;
    public Button btnCreateRole;
    public InputField inputFieldCreateRole;
    public GameObject createRolePanel;
    #endregion

    #region 技能创建界面
    public Button btnCreateSkillClose;
    public Button btnCreateSkill;
    public InputField inputFieldCreateSkill;
    public GameObject createSkillPanel;
    #endregion

    public GameObject skillScrollView;
    public GameObject roleScrollView;
    // Start is called before the first frame update
    public CardBagListMng cardBagListMng;

    public GameObject mask;

    public Button BtnShowHerAttrView;
    void Start()
    {
        btnCardBagBack.onClick.AddListener(OnClickCardBagBackBtn);

        btnShowCreateRole.onClick.AddListener(OnClickBtnCreateRole);
        btnCreateRoleClose.onClick.AddListener(OnClickbtnCreateRoleClose);
        btnCreateRole.onClick.AddListener(OnClickbtnCreateRole);
        btnDeleteHero.onClick.AddListener(OnClickDeleteHero);

        btnShowCreateSkill.onClick.AddListener(OnClickBtnCreateSkill);
        btnCreateSkillClose.onClick.AddListener(OnClickbtnCreateSkillClose);
        btnCreateSkill.onClick.AddListener(OnClickbtnCreateSkill);

        btnSkillScrollView.onClick.AddListener(OnClickShowSkillScrollView);

        BtnShowHerAttrView.onClick.AddListener(OnClickShowHerAttrView);

        createRolePanel.SetActive(false);
        createSkillPanel.SetActive(false);
        InitSkillScrollView();

    }

    // Update is called once per frame
    void Update()
    {
        bool maskActive = createRolePanel.activeSelf || createSkillPanel.activeSelf;
        if (mask.activeSelf != maskActive)
        {
            mask.SetActive(maskActive);
        }
    }
    #region 卡牌库
    private void OnClickCardBagBackBtn()
    {
        MessageManager.Instance.ShowMessage("ShowMessage : OnClickStartBtn");
        Debug.Log("OnClickStartBtn");
        SceneSwitcher.LoadSceneByIndex(ESceneType.MAINSCENE);
    }
    #endregion

    #region 创建角色
    private void OnClickBtnCreateRole()
    {
        createRolePanel.SetActive(true);
    }
    private void OnClickbtnCreateRoleClose()
    {
        if (isCreateRoleing) return;
        createRolePanel.SetActive(false);
    }
    private bool isCreateRoleing = false;
    private async void OnClickbtnCreateRole()
    {
        if (inputFieldCreateRole.text == "")
        {
            MessageManager.Instance.ShowMessage("请输入角色名字");
            return;
        }
        if (isCreateRoleing) return;
        isCreateRoleing = true;
        bool success = await PlayerModel.Instance.createRole(inputFieldCreateRole.text);
        if (success)
        {
            cardBagListMng.PopulateRoleList();
        }
        createRolePanel.SetActive(false);
        isCreateRoleing = false;
    }

    private async void OnClickDeleteHero()
    {
        if (inputFieldCreateSkill.text == "")
        {
            MessageManager.Instance.ShowMessage("请输入技能名字");
            return;
        }
        if (PlayerModel.Instance.curtHero == null)
        {
            return;
        }
        var curHeroId = PlayerModel.Instance.curtHero.id;
        if (await PlayerModel.Instance.deleteHero(curHeroId))
        {
            cardBagListMng.resetHero();
        }
    }
    #endregion

    #region 创建技能
    private void OnClickBtnCreateSkill()
    {
        createSkillPanel.SetActive(true);
    }
    private void OnClickbtnCreateSkillClose()
    {
        if (isCreateSkilling) return;
        createSkillPanel.SetActive(false);
    }
    private bool isCreateSkilling = false;
    private async void OnClickbtnCreateSkill()
    {
        if (isCreateSkilling) return;
        isCreateSkilling = true;
        bool success = await PlayerModel.Instance.createSkill(inputFieldCreateSkill.text);
        if (success)
        {
            cardBagListMng.PopulateSkillList();
        }
        createSkillPanel.SetActive(false);
        isCreateSkilling = false;
    }
    #endregion

    #region 技能列表
    private RectTransform _skillScrollViewRectTransform;
    private float _skillScrollViewHeight;
    private RectTransform _btnShowSkillRectTransform;
    private float _btnSkillScrollViewHeight;
    private RectTransform _roleScrollViewRectTransform;
    private bool _btnSkillScrollViewIsShow;
    void InitSkillScrollView()
    {
        _skillScrollViewRectTransform = skillScrollView.GetComponent<RectTransform>();
        _skillScrollViewHeight = _skillScrollViewRectTransform.rect.height;
        _btnShowSkillRectTransform = btnSkillScrollView.GetComponent<RectTransform>();
        _btnSkillScrollViewHeight = _btnShowSkillRectTransform.rect.height;

        _roleScrollViewRectTransform = roleScrollView.GetComponent<RectTransform>();
        _btnSkillScrollViewIsShow = true;

        _skillScrollViewRectTransform.offsetMin = new Vector2(0.0f, _skillScrollViewHeight - _btnSkillScrollViewHeight);
        _roleScrollViewRectTransform.offsetMax = new Vector2(0.0f, -_btnSkillScrollViewHeight);

        roleScrollView.SetActive(true);
        skillScrollView.SetActive(false);

    }
    void OnClickShowSkillScrollView()
    {
        if (_btnSkillScrollViewIsShow)
        {
            ShowSkillScrollView();
            _btnSkillScrollViewIsShow = false;
        }
        else
        {
            HideSkillScrollView();
            _btnSkillScrollViewIsShow = true;
        }
    }
    void OnClickShowHerAttrView()
    {
        if (PlayerModel.Instance.curtHero != null)
        {
            HeroInfoView.Instance.ShowHeroInfoView();
        }
        else
        {
            MessageManager.Instance.ShowMessage("请选择角色！");
        }
    }
    private void ShowSkillScrollView()
    {
        _btnShowSkillRectTransform.DOAnchorPosY(_btnSkillScrollViewHeight - _skillScrollViewHeight, 0.3f, false);
        DOTween.To(
            () => _skillScrollViewRectTransform.offsetMin,
            vec2 => _skillScrollViewRectTransform.offsetMin = vec2,
            new Vector2(0.0f, _btnSkillScrollViewHeight),
            0.3f
            ).OnComplete(() =>
    {
        roleScrollView.SetActive(false);
    });
        skillScrollView.SetActive(true);

    }
    private void HideSkillScrollView()
    {
        _btnShowSkillRectTransform.DOAnchorPosY(0.0f, 0.3f, false);

        DOTween.To(
            () => _skillScrollViewRectTransform.offsetMin,
            vec2 => _skillScrollViewRectTransform.offsetMin = vec2,
            new Vector2(0.0f, _skillScrollViewHeight - _btnSkillScrollViewHeight),
            0.3f
            ).OnComplete(() =>
        {
            skillScrollView.SetActive(false);
        });
        roleScrollView.SetActive(true);
    }
    #endregion
}
