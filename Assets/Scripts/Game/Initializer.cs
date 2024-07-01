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
    public GameObject messageManagerPrefab;
    private void Awake()
    {
        Login();

        
    }
    private async void Login()
    {
        //SyncData.Default.root = root;
        var opt = StartupOptions.Default;
        opt.url = "http://127.0.0.1:10101";
        opt.debug = true;
        O4e.Startup(opt);
        //O4e.options.url = url.text;
        var resp1 = await LoginService.AuthUser(new Login_AuthUser { platform = "debug", info = "{\"id\":\"111\"}" });
        if (resp1.code != 0)
        {
            Debug.LogError(resp1.error);
            return;
        }
        var ws = new MsgConnDelegate();
        var ok = await ws.Connect(new ConnectOptions { token = resp1.GetData().roleToken, encoding = Encoding.X });
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
}
