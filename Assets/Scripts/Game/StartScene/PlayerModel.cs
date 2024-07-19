using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.O4e;
using System.Threading.Tasks;
using Hortor.O4e.Rpc;
using Cysharp.Threading.Tasks;
using System;
using Unity.VisualScripting;
using TMPro.Examples;
using Unity.Burst.Intrinsics;
public class EGameEvent
{
    public const string NEXT_LEVEL_REFRESH = "NEXT_LEVEL_REFRESH";
    public const string SHORT_CLICK_SKILL = "SHORT_CLICK_SKILL";
    public const string LONG_CLICK_SKILL = "LONG_CLICK_SKILL";
    public const string SHORT_CLICK_ROLE = "SHORT_CLICK_ROLE";
    public const string LONG_CLICK_ROLE = "LONG_CLICK_ROLE";
}
public enum EBattleType
{
    EMPTY,
    PVE,
    PVP,
    SELF,

}
public class PlayerModel : Singleton<PlayerModel>
{
    GDUser _user;
    public GDUser user
    {
        get
        {
            return _user;
        }
        set
        {
            _user = value;
        }
    }
    GDRole _role;
    public GDRole role
    {
        get
        {
            return _role;
        }
        set
        {
            _role = value;
        }
    }
    private Hero _pveEnemy;
    public Hero pveEnemy
    {
        get
        {
            return _pveEnemy;
        }
        private set
        {
            _pveEnemy = value;
        }
    }
    Hero _curtSelectedHero;
    public Hero curtHero
    {
        get { return _curtSelectedHero; }
        set { _curtSelectedHero = value; }
    }
    private EBattleType _battleType = EBattleType.EMPTY;
    public EBattleType battleType
    {
        set
        {
            _battleType = value;
        }
        get
        {
            return _battleType;
        }
    }
    public List<Skill> _skills;
    public List<Skill> skillList
    {
        get { return _skills; }
    }
    CustomDelegateDispatcher _e = new CustomDelegateDispatcher();
    public CustomDelegateDispatcher e
    {
        get
        {
            return _e;
        }
        private set
        {
            _e = value;
        }
    }
    private void Awake()
    {
        user = new GDUser();
        DontDestroyOnLoad(this.gameObject);
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void OnDestroy()
    {
        // dispatcher.des
        base.OnDestroy();
    }
    public void setCurtHero(Hero hero)
    {
        curtHero = hero;
        _skills.Clear();
    }


    public async Task login()
    {
        SyncData.Default.root = user;
        var opt = StartupOptions.Default;
        opt.url = "http://180.184.55.2:10101";
        opt.debug = true;
        O4e.Startup(opt);

        const string UidPrefKey = "uid";
        var uid = PlayerPrefs.GetString(UidPrefKey);
        if (uid == "")
        {
            uid = await fetchNewUid();
            PlayerPrefs.SetString(UidPrefKey, uid);
        }
        ReceiveMsg<Login_AuthUserR> resp1 = await LoginService.AuthUser(new Login_AuthUser { platform = "debug", info = "{\"id\":\"" + uid + "\"}" });
        if (resp1.code != 0)
        {
            Debug.LogError(resp1.error);
            return;
        }
        var ok = await Sender.Default.Connect(new ConnectOptions { token = resp1.GetData().roleToken, encoding = Encoding.X });
        if (!ok)
        {
            Debug.LogError("连接失败");
            return;
        }
        ReceiveMsg<RespSync> resp2 = await GameService.RoleLogin(new Game_RoleLogin { });
        if (resp2.code != 0)
        {
            Debug.LogError(resp2.error);
            return;
        }
        Debug.Log("登录成功");

        role = resp2.GetData().role;
        this.init();
    }
    public async UniTask<string> fetchNewUid()
    {
        ReceiveMsg<Login_CreateNewUidR> resp = await LoginService.CreateNewUid(new Login_CreateNewUid() { });
        if (resp.code != 0)
        {
            return "111";
        }
        Debug.Log(resp.GetData().data);
        return resp.GetData().data;
    }
    public void init()
    {
        _skills = new List<Skill>();
        if (role.heros.Count > 0)
        {
            curtHero = role.heros[0];
        }

    }
    public async UniTask<bool> createRole(string roleName)
    {
        var resp = await GameService.CreateHero(new Game_CreateHero { name = roleName });
        Game_CreateHeroR roleData = resp.GetData();
        if (roleData != null)
        {
            Hero role = roleData.data;
            this.role.heros.Add(role);
            MessageManager.Instance.ShowMessage("创建卡牌成功");
            return true;
        }
        else
        {
            MessageManager.Instance.ShowMessage("创建卡牌失败，请稍后重试!");
            return false;
        }
    }
    public async UniTask<bool> deleteHero(long heroId)
    {
        var resp = await GameService.DeleteHero(new Game_DeleteHero() { heroId = heroId });
        Game_DeleteHeroR roleData = resp.GetData();
        if (roleData != null)
        {
            setCurtHero(null);
            var roleHeros = role.heros;
            int removeI = -1;
            for (int i = 0; i < roleHeros.Count; i++)
            {
                if (roleHeros[i].id == heroId)
                {
                    removeI = i;
                    break;
                }
            }

            if (removeI != -1)
            {
                roleHeros.RemoveAt(removeI);
                role.heros = roleHeros;
            }
            return true;
        }
        else
        {
            MessageManager.Instance.ShowMessage("删除英雄失败，请稍后重试!");
            return false;
        }
    }
    public void initHeroAttrList()
    {
        _skills.Clear();
        _skills = curtHero.battleSkills;
    }
    public async UniTask<bool> createSkill(string skillName)
    {
        if (curtHero.skills == null)
        {
            MessageManager.Instance.ShowMessage("没有角色，请先创建角色");
            return false;
        }
        var resp = await GameService.CreateSkill(new Game_CreateSkill { heroId = curtHero.id, desc = skillName });
        Game_CreateSkillR roleData = resp.GetData();
        if (roleData != null)
        {
            Skill skill = roleData.data;
            curtHero.skills.Add(skill);
            MessageManager.Instance.ShowMessage("创建技能成功");
            return true;
        }
        else
        {
            MessageManager.Instance.ShowMessage("创建技能失败，请稍后重试!");
            return false;
        }
    }
    public void addSkill2List(Skill skill)
    {
        _skills.Add(skill);
    }
    public void removeSkill2List(Skill skill)
    {
        _skills.Remove(skill);
    }
    public async UniTask<bool> setRoleBattleSkills(long heroId, List<long> skillIds)
    {
        var resp = await GameService.SetBattleSkills(new Game_SetBattleSkills { heroId = heroId, skillIds = skillIds });
        Game_SetBattleSkillsR battleSkillsR = resp.GetData();
        if (battleSkillsR != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public async UniTask<bool> StartPevBattleAsync(long roleId)
    {
        var resp = await GameService.FinishNextLevelBattle(new Game_FinishNextLevelBattle { heroId = roleId });
        Game_FinishNextLevelBattleR finishNextLevelBattleR = resp.GetData();
        if (finishNextLevelBattleR == null)
        {
            return false;
        }
        BattleManager.Instance.SetBattleManager(finishNextLevelBattleR.data);
        _pveEnemy = null;
        return true;
    }
    public async UniTask<BattleFinishResp> startBattle(long heroId)
    {

        var respStartBattle = await GameService.StartBattle(new Game_StartBattle
        {
            roleId1 = role.id,
            player1 = heroId,
            roleId2 = role.id,
            player2 = role.heros[0].id
        });
        Game_StartBattleR battleSkillsR = respStartBattle.GetData();
        if (battleSkillsR == null)
        {
            return null;
        }

        var respFinishBattle = await GameService.FinishBattle(new Game_FinishBattle { battleId = battleSkillsR.data.id });
        Game_FinishBattleR finishBattleR = respFinishBattle.GetData();
        if (finishBattleR == null)
        {
            return null;
        }
        BattleManager.Instance.SetBattleManager(finishBattleR.data);
        return finishBattleR.data;
    }

    public async void GetNextPveEnemyInfoAsync()
    {
        if (_pveEnemy != null) return;
        //获取下一个敌人信息
        var resp = await GameService.GetNextLevel(new Game_GetNextLevel { });
        Game_GetNextLevelR nextLevelR = resp.GetData();
        if (nextLevelR != null)
        {
            _pveEnemy = nextLevelR?.data?.enemy;
            Debug.Log("获取下一个敌人信息成功");
            e.TriggerEvent(EGameEvent.NEXT_LEVEL_REFRESH, _pveEnemy);
        }
    }
}

