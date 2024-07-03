using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CardBagSceneBtnManager : MonoBehaviour
{

    public Button btnCardBagBack;

    public Button btnShowCreateRole;
    public Button btnShowCreateSkill;


    public Button btnCreateRoleClose;
    public Button btnCreateRole;
    public InputField inputFieldCreateRole;
    public GameObject createRolePanel;

    public Button btnCreateSkillClose;
    public Button btnCreateSkill;
    public InputField inputFieldCreateSkill;
    public GameObject createSkillPanel;

    // Start is called before the first frame update
    void Start()
    {
        btnCardBagBack.onClick.AddListener(OnClickCardBagBackBtn);

        btnShowCreateRole.onClick.AddListener(OnClickBtnCreateRole);
        btnCreateRoleClose.onClick.AddListener(onClickbtnCreateRoleClose);
        btnCreateRole.onClick.AddListener(onClickbtnCreateRole);

        btnShowCreateSkill.onClick.AddListener(OnClickBtnCreateSkill);
        btnCreateSkillClose.onClick.AddListener(onClickbtnCreateSkillClose);
        btnCreateSkill.onClick.AddListener(onClickbtnCreateSkill);

        btnCreateSkill.onClick.AddListener(OnClickBtnCreateSkill);

        createRolePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    #region CardBag
    private void OnClickCardBagBackBtn()
    {
        MessageManager.Instance.ShowMessage("ShowMessage : OnClickStartBtn");
        Debug.Log("OnClickStartBtn");
        SceneSwitcher.LoadSceneByIndex(ESceneType.MAINSCENE);
    }
    #endregion

    #region CreateRole
    private void OnClickBtnCreateRole()
    {
        createRolePanel.SetActive(true);
    }
    private void onClickbtnCreateRoleClose()
    {
        createRolePanel.SetActive(false);
    }
    private async void onClickbtnCreateRole()
    {
        var resp = await GameService.CreateHero(new Game_CreateHero { });
        if (resp.code != 0)
        {
            Game_CreateHeroR roleData = resp.GetData();
            Hero role = roleData.data;
            PlayerModel.Instance.addRole(role);
            MessageManager.Instance.ShowMessage("创建卡牌成功");
            createRolePanel.SetActive(false);
        }
        else
        {
            createRolePanel.SetActive(false);
            MessageManager.Instance.ShowMessage("创建卡牌失败，请稍后重试!");
        }
    }
    #endregion  
    #region CreateSkill
    private void OnClickBtnCreateSkill()
    {
        createRolePanel.SetActive(true);
    }
    private void onClickbtnCreateSkillClose()
    {
        createRolePanel.SetActive(false);
    }
    private async void onClickbtnCreateSkill()
    {
        var resp = await GameService.CreateSkill(new Game_CreateSkill { });
        if (resp.code != 0)
        {
            Game_CreateSkillR roleData = resp.GetData();
            CardSkill role = roleData.data;

            MessageManager.Instance.ShowMessage("创建技能成功");
            createRolePanel.SetActive(false);
        }
        else
        {
            createRolePanel.SetActive(false);
            MessageManager.Instance.ShowMessage("创建技能失败，请稍后重试!");
        }
    }
    #endregion
}
