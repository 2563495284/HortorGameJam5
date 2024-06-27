using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hortor.O4e.Data;
using Hortor.O4e.Rpc;
using Hortor.Bon;
public partial class IsolateOIMService : ServiceBase
{
    public IsolateOIMService(Isolate isolate) : base(isolate)
    {
    }
    public void DelConversation(OIM_DelConversation data, CmdOption opt = default)
	{
        Send(ToSendMsg("oim_delconversation", data, opt));
    }
    public Task<ReceiveMsg<OIM_GetConversationListResp>> GetConversationList(OIM_GetConversationList data, CmdOption opt = default)
	{
        return SendAsync<OIM_GetConversationListResp>(ToSendMsg("oim_getconversationlist", data, opt));
    }
    public Task<ReceiveMsg<OIM_GetHistoryResp>> GetHistory(OIM_GetHistory data, CmdOption opt = default)
	{
        return SendAsync<OIM_GetHistoryResp>(ToSendMsg("oim_gethistory", data, opt));
    }
    public void SendMsg(OIM_SendMsg data, CmdOption opt = default)
	{
        Send(ToSendMsg("oim_sendmsg", data, opt));
    }
}

public partial class OIMService
{
    public static void DelConversation(OIM_DelConversation data, CmdOption opt = default)
	{
        Isolate.Default.OIMService.DelConversation(data, opt);
    }
    public static Task<ReceiveMsg<OIM_GetConversationListResp>> GetConversationList(OIM_GetConversationList data, CmdOption opt = default)
	{
        return Isolate.Default.OIMService.GetConversationList(data, opt);
    }
    public static Task<ReceiveMsg<OIM_GetHistoryResp>> GetHistory(OIM_GetHistory data, CmdOption opt = default)
	{
        return Isolate.Default.OIMService.GetHistory(data, opt);
    }
    public static void SendMsg(OIM_SendMsg data, CmdOption opt = default)
	{
        Isolate.Default.OIMService.SendMsg(data, opt);
    }
}


