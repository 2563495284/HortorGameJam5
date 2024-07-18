using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hortor.O4e.Data;
using Hortor.O4e.Rpc;
using Hortor.Bon;
public partial class IsolateLoginService : ServiceBase
{
    public IsolateLoginService(Isolate isolate) : base(isolate)
    {
    }
    public Task<ReceiveMsg<Login_AuthUserR>> AuthUser(Login_AuthUser data, CmdOption opt = default)
	{
        opt.useHttp ??= true;
        return SendAsync<Login_AuthUserR>(ToSendMsg("login_authuser", data, opt));
    }
    public Task<ReceiveMsg<Login_CreateNewUidR>> CreateNewUid(Login_CreateNewUid data, CmdOption opt = default)
	{
        opt.useHttp ??= true;
        return SendAsync<Login_CreateNewUidR>(ToSendMsg("login_createnewuid", data, opt));
    }
}

public partial class LoginService
{
    public static Task<ReceiveMsg<Login_AuthUserR>> AuthUser(Login_AuthUser data, CmdOption opt = default)
	{
        return Isolate.Default.LoginService.AuthUser(data, opt);
    }
    public static Task<ReceiveMsg<Login_CreateNewUidR>> CreateNewUid(Login_CreateNewUid data, CmdOption opt = default)
	{
        return Isolate.Default.LoginService.CreateNewUid(data, opt);
    }
}


