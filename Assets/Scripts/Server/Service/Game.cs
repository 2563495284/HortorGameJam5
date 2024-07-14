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
    /// 加入技能库
    /// <summary>
    public Task<ReceiveMsg<Game_ConfirmSkillR>> ConfirmSkill(Game_ConfirmSkill data, CmdOption opt = default)
	{
        return SendAsync<Game_ConfirmSkillR>(ToSendMsg("game_confirmskill", data, opt));
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
    /// <summary>
    /// 下一关对战
    /// <summary>
    public Task<ReceiveMsg<Game_FinishNextLevelBattleR>> FinishNextLevelBattle(Game_FinishNextLevelBattle data, CmdOption opt = default)
	{
        return SendAsync<Game_FinishNextLevelBattleR>(ToSendMsg("game_finishnextlevelbattle", data, opt));
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
    /// 下一关敌人
    /// <summary>
    public Task<ReceiveMsg<Game_GetNextLevelR>> GetNextLevel(Game_GetNextLevel data, CmdOption opt = default)
	{
        return SendAsync<Game_GetNextLevelR>(ToSendMsg("game_getnextlevel", data, opt));
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
    /// 设置启用英雄
    /// <summary>
    public Task<ReceiveMsg<Game_SetActiveHeroR>> SetActiveHero(Game_SetActiveHero data, CmdOption opt = default)
	{
        return SendAsync<Game_SetActiveHeroR>(ToSendMsg("game_setactivehero", data, opt));
    }
    /// <summary>
    /// 调整上阵技能
    /// <summary>
    public Task<ReceiveMsg<Game_SetBattleSkillsR>> SetBattleSkills(Game_SetBattleSkills data, CmdOption opt = default)
	{
        return SendAsync<Game_SetBattleSkillsR>(ToSendMsg("game_setbattleskills", data, opt));
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
    /// 加入技能库
    /// <summary>
    public static Task<ReceiveMsg<Game_ConfirmSkillR>> ConfirmSkill(Game_ConfirmSkill data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.ConfirmSkill(data, opt);
    }
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
    /// <summary>
    /// 下一关对战
    /// <summary>
    public static Task<ReceiveMsg<Game_FinishNextLevelBattleR>> FinishNextLevelBattle(Game_FinishNextLevelBattle data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.FinishNextLevelBattle(data, opt);
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
    /// 下一关敌人
    /// <summary>
    public static Task<ReceiveMsg<Game_GetNextLevelR>> GetNextLevel(Game_GetNextLevel data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.GetNextLevel(data, opt);
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
    /// 设置启用英雄
    /// <summary>
    public static Task<ReceiveMsg<Game_SetActiveHeroR>> SetActiveHero(Game_SetActiveHero data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.SetActiveHero(data, opt);
    }
    /// <summary>
    /// 调整上阵技能
    /// <summary>
    public static Task<ReceiveMsg<Game_SetBattleSkillsR>> SetBattleSkills(Game_SetBattleSkills data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.SetBattleSkills(data, opt);
    }
    /// <summary>
    /// 战斗开始
    /// <summary>
    public static Task<ReceiveMsg<Game_StartBattleR>> StartBattle(Game_StartBattle data, CmdOption opt = default)
	{
        return Isolate.Default.GameService.StartBattle(data, opt);
    }
}


