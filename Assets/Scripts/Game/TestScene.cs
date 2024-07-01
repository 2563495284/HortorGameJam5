using System;
using System.Linq;
using System.Reflection;
using Hortor.O4e;
using Hortor.O4e.Data;
using Hortor.O4e.Rpc;
using TMPro;
using UnityEngine;
using Hortor.Common;

public class DataRoot
{
    public GDRole role = new();
}

public class TestScene : MonoBehaviour
{

    DataRoot root = new();
    void Start()
    {
        SyncData.Default.root = root;
        var opt = StartupOptions.Default;
        opt.url = "http://10.1.0.24:10101";
        opt.debug = true;
        O4e.Startup(opt);
    }

    async void Login(string protocol)
    {
        //O4e.options.url = url.text;
        var resp1 = await LoginService.AuthUser(new Login_AuthUser { platform = "debug", info = "{\"id\":\"111\"}" });
        if (resp1.code != 0)
        {
            Debug.LogError(resp1.error);
            return;
        }
        var ok = await Sender.Default.Connect(new ConnectOptions { token = resp1.GetData().roleToken, encoding = Encoding.X, protocol = protocol });
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

    public void Test()
    {
    }


    public void Update()
    {
    }
}