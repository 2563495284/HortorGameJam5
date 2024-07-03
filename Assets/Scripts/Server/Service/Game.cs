using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hortor.O4e.Data;
using Hortor.O4e.Rpc;
using Hortor.Bon;
public partial class IsolateGameService : ServiceBase
{
    public IsolateGameService(Isolate isolate) : base(isolate)
    {
    }
    /// <summary>
    /// 创建英雄
    /// <summary>
    public Task<ReceiveMsg<Game_CreateHeroR>> CreateHero(Game_CreateHero data, CmdOption opt = default)
	{
        return SendAsync<Game_CreateHeroR>(ToSendMsg("game_createhero", data, opt));
    }
    /// <summary>
    /// 创建技能
    /// <summary>
    public Task<ReceiveMsg<Game_CreateSkillR>> CreateSkill(Game_CreateSkill data, CmdOption opt = default)
	{
        return SendAsync<Game_CreateSkillR>(ToSendMsg("game_createskill", data, opt));
    }
    public Task<ReceiveMsg<Game_DeleteAllHeroR>> DeleteAllHero(Game_DeleteAllHero data, CmdOption opt = default)
	{
        return SendAsync<Game_DeleteAllHeroR>(ToSendMsg("game_deleteallhero", data, opt));
    }
    /// <summary>
    /// 删除英雄
    /// <summary>
    public Task<ReceiveMsg<Game_DeleteHeroR>> DeleteHero(Game_DeleteHero data, CmdOption opt = default)
	{
        return SendAsync<Game_DeleteHeroR>(ToSendMsg("game_deletehero", data, opt));
    }
    /// <summary>
    /// echo示例
    /// <summary>
    public Task<ReceiveMsg<Game_EchoR>> Echo(Game_Echo data, CmdOption opt = default)
	{
        return SendAsync<Game_EchoR>(ToSendMsg("game_echo", data, opt));
    }
    /// <summary>
    /// 战斗演示
    /// <summary>
    public Task<ReceiveMsg<Game_FinishBattleR>> FinishBattle(Game_FinishBattle data, CmdOption opt = default)
	{
        return SendAsync<Game_FinishBattleR>(ToSendMsg("game_finishbattle", data, opt));
    }
    public Task<ReceiveMsg<Game_GetAllHerosR>> GetAllHeros(Game_GetAllHeros data, CmdOption opt = default)
	{
        return SendAsync<Game_GetAllHerosR>(ToSendMsg("game_getallheros", data, opt));
    }
    public Task<ReceiveMsg<Game_GetHeroR>> GetHero(Game_GetHero data, CmdOption opt = default)
	{
        return SendAsync<Game_GetHeroR>(ToSendMsg("game_gethero", data, opt));
    }
    /// <summary>
    /// 战斗结算
    /// <summary>
    public Task<ReceiveMsg<Game_NextRoundR>> NextRound(Game_NextRound data, CmdOption opt = default)
	{
        return SendAsync<Game_NextRoundR>(ToSendMsg("game_nextround", data, opt));
    }
    /// <summary>
    /// 角色登陆
    /// <summary>
    public Task<ReceiveMsg<RespSync>> RoleLogin(Game_RoleLogin data, CmdOption opt = default)
	{
        return SendAsync<RespSync>(ToSendMsg("game_rolelogin", data, opt));
    }
    public Task<ReceiveMsg<RespSync>> SaveAvatar(Game_SaveAvatar data, CmdOption opt = default)
	{
        return SendAsync<RespSync>(ToSendMsg("game_saveavatar", data, opt));
    }
    /// <summary>
    /// 战斗开始
    /// <summary>
    public Task<ReceiveMsg<Game_StartBattleR>> StartBattle(Game_StartBattle data, CmdOption opt = default)
	{
        return SendAsync<Game_StartBattleR>(ToSendMsg("game_startbattle", data, opt));
    }
}

public partial class GameService
{
    /// <summary>
    /// 创建英雄
    /// <summary>
    public static Task<ReceiveMsg<Game_CreateHeroR>> CreateHero(Game_CreateHero data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.CreateHero(data, opt);
    }
    /// <summary>
    /// 创建技能
    /// <summary>
    public static Task<ReceiveMsg<Game_CreateSkillR>> CreateSkill(Game_CreateSkill data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.CreateSkill(data, opt);
    }
    public static Task<ReceiveMsg<Game_DeleteAllHeroR>> DeleteAllHero(Game_DeleteAllHero data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.DeleteAllHero(data, opt);
    }
    /// <summary>
    /// 删除英雄
    /// <summary>
    public static Task<ReceiveMsg<Game_DeleteHeroR>> DeleteHero(Game_DeleteHero data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.DeleteHero(data, opt);
    }
    /// <summary>
    /// echo示例
    /// <summary>
    public static Task<ReceiveMsg<Game_EchoR>> Echo(Game_Echo data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.Echo(data, opt);
    }
    /// <summary>
    /// 战斗演示
    /// <summary>
    public static Task<ReceiveMsg<Game_FinishBattleR>> FinishBattle(Game_FinishBattle data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.FinishBattle(data, opt);
    }
    public static Task<ReceiveMsg<Game_GetAllHerosR>> GetAllHeros(Game_GetAllHeros data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.GetAllHeros(data, opt);
    }
    public static Task<ReceiveMsg<Game_GetHeroR>> GetHero(Game_GetHero data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.GetHero(data, opt);
    }
    /// <summary>
    /// 战斗结算
    /// <summary>
    public static Task<ReceiveMsg<Game_NextRoundR>> NextRound(Game_NextRound data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.NextRound(data, opt);
    }
    /// <summary>
    /// 角色登陆
    /// <summary>
    public static Task<ReceiveMsg<RespSync>> RoleLogin(Game_RoleLogin data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.RoleLogin(data, opt);
    }
    public static Task<ReceiveMsg<RespSync>> SaveAvatar(Game_SaveAvatar data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.SaveAvatar(data, opt);
    }
    /// <summary>
    /// 战斗开始
    /// <summary>
    public static Task<ReceiveMsg<Game_StartBattleR>> StartBattle(Game_StartBattle data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.StartBattle(data, opt);
    }
}


