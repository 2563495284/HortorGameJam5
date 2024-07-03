//using cfg;
using Hortor.O4e;
using Hortor.O4e.Data;
using Hortor.O4e.Rpc;
using SimpleJSON;
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class Initializer : MonoBehaviour
{

    public GDRole role = new();
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Login();

    }
    private async void Login()
    {
        SyncData.Default.root = role;
        var opt = StartupOptions.Default;
        opt.url = "http://180.184.55.2:10101";
        opt.debug = true;
        O4e.Startup(opt);
        //O4e.options.url = url.text;
        var resp1 = await LoginService.AuthUser(new Login_AuthUser { platform = "debug", info = "{\"id\":\"111\"}" });
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
        var resp2 = await GameService.RoleLogin(new Game_RoleLogin { });
        if (resp2.code != 0)
        {
            Debug.LogError(resp2.error);
            return;
        }
        Debug.Log("登录成功");
    }
    private void Start()
    {
    }
}

