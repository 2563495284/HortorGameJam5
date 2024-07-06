using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hortor.O4e.Data;
using Hortor.O4e;
using System.Threading.Tasks;
using Hortor.O4e.Rpc;
using Cysharp.Threading.Tasks;

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
    CustomDelegateDispatcher _dispatcher = new CustomDelegateDispatcher();
    public CustomDelegateDispatcher dispatcher
    {
        get
        {
            return _dispatcher;
        }
        set
        {
            _dispatcher = value;
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
    public async Task login()
    {
        SyncData.Default.root = user;
        var opt = StartupOptions.Default;
        opt.url = "http://180.184.55.2:10101";
        opt.debug = true;
        O4e.Startup(opt);
        ReceiveMsg<Login_AuthUserR> resp1 = await LoginService.AuthUser(new Login_AuthUser { platform = "debug", info = "{\"id\":\"111\"}" });
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
    }
    public async UniTask<bool> createRole()
    {
        var resp = await GameService.CreateHero(new Game_CreateHero { });
        if (resp.code != 0)
        {
            Game_CreateHeroR roleData = resp.GetData();
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
    public async UniTask<bool> createSkill()
    {
        var resp = await GameService.CreateSkill(new Game_CreateSkill { });
        if (resp.code != 0)
        {
            Game_CreateSkillR roleData = resp.GetData();
            Skill skill = roleData.data;
            // this.role.heros.Add(role);
            MessageManager.Instance.ShowMessage("创建技能成功");
            return true;
        }
        else
        {
            MessageManager.Instance.ShowMessage("创建技能失败，请稍后重试!");
            return false;
        }
    }

}

