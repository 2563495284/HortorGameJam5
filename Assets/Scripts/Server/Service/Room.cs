using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hortor.O4e.Data;
using Hortor.O4e.Rpc;
using Hortor.Bon;
public partial class IsolateRoomService : ServiceBase
{
    public IsolateRoomService(Isolate isolate) : base(isolate)
    {
    }
    /// <summary>
    /// 分配空闲房间服务器id，用于创建房间
    /// <summary>
    public Task<ReceiveMsg<Room_AllocServerR>> AllocServer(Room_AllocServer data, CmdOption opt = default)
	{
        return SendAsync<Room_AllocServerR>(ToSendMsg("room_allocserver", data, opt));
    }
    /// <summary>
    /// 更新房间自定义消息
    /// <summary>
    public Task<ReceiveMsg<Room_CustomChangeP>> ChangeCustom(Room_ChangeCustom data, CmdOption opt = default)
	{
        return SendAsync<Room_CustomChangeP>(ToSendMsg("room_changecustom", data, opt));
    }
    /// <summary>
    /// 调整玩家分组信息
    /// <summary>
    public Task<ReceiveMsg<Room_RoleGroupChangeP>> ChangeRoleGroup(Room_ChangeRoleGroup data, CmdOption opt = default)
	{
        return SendAsync<Room_RoleGroupChangeP>(ToSendMsg("room_changerolegroup", data, opt));
    }
    /// <summary>
    /// 创建房间
    /// <summary>
    public Task<ReceiveMsg<Room_Resp>> Create(Room_Create data, CmdOption opt = default)
	{
        return SendAsync<Room_Resp>(ToSendMsg("room_create", data, opt));
    }
    /// <summary>
    /// 解散房间
    /// <summary>
    public Task<ReceiveMsg<Room_DismissP>> Dismiss(Room_Dismiss data, CmdOption opt = default)
	{
        return SendAsync<Room_DismissP>(ToSendMsg("room_dismiss", data, opt));
    }
    /// <summary>
    /// 发送帧同步消息
    /// <summary>
    public void FrameMsg(Room_FrameMsg data, CmdOption opt = default)
	{
        Send(ToSendMsg(1108968696370464336, data, opt));
    }
    /// <summary>
    /// 查询空闲房间id列表
    /// <summary>
    public Task<ReceiveMsg<Room_FreeIdListR>> FreeIdList(Room_FreeIdList data, CmdOption opt = default)
	{
        return SendAsync<Room_FreeIdListR>(ToSendMsg("room_freeidlist", data, opt));
    }
    /// <summary>
    /// 补帧，遗漏的帧会分批发送到客户端，客户端需要做缓冲处理
    /// <summary>
    public void GetLostFrameMsg(Room_GetLostFrameMsg data, CmdOption opt = default)
	{
        Send(ToSendMsg("room_getlostframemsg", data, opt));
    }
    /// <summary>
    /// 根据房间id获取房间服务器id
    /// <summary>
    public Task<ReceiveMsg<Room_GetServerR>> GetServer(Room_GetServer data, CmdOption opt = default)
	{
        return SendAsync<Room_GetServerR>(ToSendMsg("room_getserver", data, opt));
    }
    /// <summary>
    /// 加入房间
    /// <summary>
    public Task<ReceiveMsg<Room_Resp>> Join(Room_Join data, CmdOption opt = default)
	{
        return SendAsync<Room_Resp>(ToSendMsg("room_join", data, opt));
    }
    /// <summary>
    /// 离开房间
    /// <summary>
    public Task<ReceiveMsg<Room_RoleLeaveP>> Leave(Room_Leave data, CmdOption opt = default)
	{
        return SendAsync<Room_RoleLeaveP>(ToSendMsg("room_leave", data, opt));
    }
    /// <summary>
    /// 获取房间列表
    /// <summary>
    public Task<ReceiveMsg<Room_ListR>> List(Room_List data, CmdOption opt = default)
	{
        return SendAsync<Room_ListR>(ToSendMsg("room_list", data, opt));
    }
    /// <summary>
    /// 锁定房间
    /// <summary>
    public Task<ReceiveMsg<Room_LockP>> Lock(Room_Lock data, CmdOption opt = default)
	{
        return SendAsync<Room_LockP>(ToSendMsg("room_lock", data, opt));
    }
    /// <summary>
    /// master加入房间
    /// <summary>
    public Task<ReceiveMsg<Room_Resp>> MasterJoin(Room_MasterJoin data, CmdOption opt = default)
	{
        return SendAsync<Room_Resp>(ToSendMsg("room_masterjoin", data, opt));
    }
    /// <summary>
    /// master开始
    /// <summary>
    public void MasterStart(Room_MasterStart data, CmdOption opt = default)
	{
        Send(ToSendMsg("room_masterstart", data, opt));
    }
    /// <summary>
    /// 发送房间消息
    /// <summary>
    public void Msg(Room_Msg data, CmdOption opt = default)
	{
        Send(ToSendMsg("room_msg", data, opt));
    }
    /// <summary>
    /// 开始房间
    /// <summary>
    public void Start(Room_Start data, CmdOption opt = default)
	{
        Send(ToSendMsg("room_start", data, opt));
    }
    /// <summary>
    /// 开启帧同步
    /// <summary>
    public void StartFrameSync(Room_StartFrameSync data, CmdOption opt = default)
	{
        Send(ToSendMsg("room_startframesync", data, opt));
    }
    /// <summary>
    /// 停止房间
    /// <summary>
    public void Stop(Room_Stop data, CmdOption opt = default)
	{
        Send(ToSendMsg("room_stop", data, opt));
    }
    /// <summary>
    /// 停止帧同步
    /// <summary>
    public void StopFrameSync(Room_StopFrameSync data, CmdOption opt = default)
	{
        Send(ToSendMsg("room_stopframesync", data, opt));
    }
    /// <summary>
    /// 解锁房间
    /// <summary>
    public Task<ReceiveMsg<Room_UnlockP>> Unlock(Room_Unlock data, CmdOption opt = default)
	{
        return SendAsync<Room_UnlockP>(ToSendMsg("room_unlock", data, opt));
    }
}

public partial class RoomService
{
    /// <summary>
    /// 分配空闲房间服务器id，用于创建房间
    /// <summary>
    public static Task<ReceiveMsg<Room_AllocServerR>> AllocServer(Room_AllocServer data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.AllocServer(data, opt);
    }
    /// <summary>
    /// 更新房间自定义消息
    /// <summary>
    public static Task<ReceiveMsg<Room_CustomChangeP>> ChangeCustom(Room_ChangeCustom data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.ChangeCustom(data, opt);
    }
    /// <summary>
    /// 调整玩家分组信息
    /// <summary>
    public static Task<ReceiveMsg<Room_RoleGroupChangeP>> ChangeRoleGroup(Room_ChangeRoleGroup data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.ChangeRoleGroup(data, opt);
    }
    /// <summary>
    /// 创建房间
    /// <summary>
    public static Task<ReceiveMsg<Room_Resp>> Create(Room_Create data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.Create(data, opt);
    }
    /// <summary>
    /// 解散房间
    /// <summary>
    public static Task<ReceiveMsg<Room_DismissP>> Dismiss(Room_Dismiss data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.Dismiss(data, opt);
    }
    /// <summary>
    /// 发送帧同步消息
    /// <summary>
    public static void FrameMsg(Room_FrameMsg data, CmdOption opt = default)
	{
        Isolate.Default.RoomService.FrameMsg(data, opt);
    }
    /// <summary>
    /// 查询空闲房间id列表
    /// <summary>
    public static Task<ReceiveMsg<Room_FreeIdListR>> FreeIdList(Room_FreeIdList data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.FreeIdList(data, opt);
    }
    /// <summary>
    /// 补帧，遗漏的帧会分批发送到客户端，客户端需要做缓冲处理
    /// <summary>
    public static void GetLostFrameMsg(Room_GetLostFrameMsg data, CmdOption opt = default)
	{
        Isolate.Default.RoomService.GetLostFrameMsg(data, opt);
    }
    /// <summary>
    /// 根据房间id获取房间服务器id
    /// <summary>
    public static Task<ReceiveMsg<Room_GetServerR>> GetServer(Room_GetServer data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.GetServer(data, opt);
    }
    /// <summary>
    /// 加入房间
    /// <summary>
    public static Task<ReceiveMsg<Room_Resp>> Join(Room_Join data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.Join(data, opt);
    }
    /// <summary>
    /// 离开房间
    /// <summary>
    public static Task<ReceiveMsg<Room_RoleLeaveP>> Leave(Room_Leave data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.Leave(data, opt);
    }
    /// <summary>
    /// 获取房间列表
    /// <summary>
    public static Task<ReceiveMsg<Room_ListR>> List(Room_List data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.List(data, opt);
    }
    /// <summary>
    /// 锁定房间
    /// <summary>
    public static Task<ReceiveMsg<Room_LockP>> Lock(Room_Lock data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.Lock(data, opt);
    }
    /// <summary>
    /// master加入房间
    /// <summary>
    public static Task<ReceiveMsg<Room_Resp>> MasterJoin(Room_MasterJoin data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.MasterJoin(data, opt);
    }
    /// <summary>
    /// master开始
    /// <summary>
    public static void MasterStart(Room_MasterStart data, CmdOption opt = default)
	{
        Isolate.Default.RoomService.MasterStart(data, opt);
    }
    /// <summary>
    /// 发送房间消息
    /// <summary>
    public static void Msg(Room_Msg data, CmdOption opt = default)
	{
        Isolate.Default.RoomService.Msg(data, opt);
    }
    /// <summary>
    /// 开始房间
    /// <summary>
    public static void Start(Room_Start data, CmdOption opt = default)
	{
        Isolate.Default.RoomService.Start(data, opt);
    }
    /// <summary>
    /// 开启帧同步
    /// <summary>
    public static void StartFrameSync(Room_StartFrameSync data, CmdOption opt = default)
	{
        Isolate.Default.RoomService.StartFrameSync(data, opt);
    }
    /// <summary>
    /// 停止房间
    /// <summary>
    public static void Stop(Room_Stop data, CmdOption opt = default)
	{
        Isolate.Default.RoomService.Stop(data, opt);
    }
    /// <summary>
    /// 停止帧同步
    /// <summary>
    public static void StopFrameSync(Room_StopFrameSync data, CmdOption opt = default)
	{
        Isolate.Default.RoomService.StopFrameSync(data, opt);
    }
    /// <summary>
    /// 解锁房间
    /// <summary>
    public static Task<ReceiveMsg<Room_UnlockP>> Unlock(Room_Unlock data, CmdOption opt = default)
	{
        return Isolate.Default.RoomService.Unlock(data, opt);
    }
}


