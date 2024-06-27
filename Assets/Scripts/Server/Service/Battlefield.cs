using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hortor.O4e.Data;
using Hortor.O4e.Rpc;
using Hortor.Bon;
public partial class IsolateBattlefieldService : ServiceBase
{
    public IsolateBattlefieldService(Isolate isolate) : base(isolate)
    {
    }
    /// <summary>
    /// 根据战场id获取战场服务器id
    /// <summary>
    public Task<ReceiveMsg<Battlefield_GetServerR>> GetServer(Battlefield_GetServer data, CmdOption opt = default)
	{
        return SendAsync<Battlefield_GetServerR>(ToSendMsg("battlefield_getserver", data, opt));
    }
    /// <summary>
    /// 加入战场
    /// <summary>
    public Task<ReceiveMsg<Battlefield_Resp>> Join(Battlefield_Join data, CmdOption opt = default)
	{
        return SendAsync<Battlefield_Resp>(ToSendMsg("battlefield_join", data, opt));
    }
    /// <summary>
    /// 离开战场
    /// <summary>
    public Task<ReceiveMsg<Battlefield_RoleLeaveP>> Leave(Battlefield_Leave data, CmdOption opt = default)
	{
        return SendAsync<Battlefield_RoleLeaveP>(ToSendMsg("battlefield_leave", data, opt));
    }
}

public partial class BattlefieldService
{
    /// <summary>
    /// 根据战场id获取战场服务器id
    /// <summary>
    public static Task<ReceiveMsg<Battlefield_GetServerR>> GetServer(Battlefield_GetServer data, CmdOption opt = default)
	{
        return Isolate.Default.BattlefieldService.GetServer(data, opt);
    }
    /// <summary>
    /// 加入战场
    /// <summary>
    public static Task<ReceiveMsg<Battlefield_Resp>> Join(Battlefield_Join data, CmdOption opt = default)
	{
        return Isolate.Default.BattlefieldService.Join(data, opt);
    }
    /// <summary>
    /// 离开战场
    /// <summary>
    public static Task<ReceiveMsg<Battlefield_RoleLeaveP>> Leave(Battlefield_Leave data, CmdOption opt = default)
	{
        return Isolate.Default.BattlefieldService.Leave(data, opt);
    }
}


