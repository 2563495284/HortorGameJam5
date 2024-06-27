using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hortor.O4e.Data;
using Hortor.O4e.Rpc;
public partial class Isolate
{
    public static Isolate Default = new();
    public ISender sender;
    public IsolateBattlefieldService BattlefieldService;
    public IsolateGameService GameService;
    public IsolateLoginService LoginService;
    public IsolateOIMService OIMService;
    public IsolatePayService PayService;
    public IsolateRoomService RoomService;

    public Isolate(ISender sender = null)
    {
        this.sender = sender ?? Sender.Current;
        BattlefieldService = new(this);
        GameService = new(this);
        LoginService = new(this);
        OIMService = new(this);
        PayService = new(this);
        RoomService = new(this);
    }
}

public struct CmdOption
{
    public string hint;
    public bool? useHttp;
    public int httpTimeout;
    public Dictionary<string, string> httpHeaders;
}

public partial class ServiceBase
{
    public struct SendArg
    {
        public string cmd;
        public long c;
        public object data;
        public CmdOption opt;
    }
    public Isolate isolate;

    public ServiceBase(Isolate isolate)
    {
        this.isolate = isolate;
    }

    public SendMsg ToSendMsg(string cmd, long c, object data, CmdOption opt)
    {
        SendMsg msg = new() { cmd = cmd, c = c, data = data, useHttp = opt.useHttp == true };
        if (msg.useHttp)
        {
            msg.timeout = opt.httpTimeout;
            msg.headers = opt.httpHeaders;
        }
        return msg;
    }

    public SendMsg ToSendMsg(string cmd, object data, CmdOption opt)
    {
        return ToSendMsg(cmd, 0, data, opt);
    }

    public SendMsg ToSendMsg(long c, object data, CmdOption opt)
    {
        return ToSendMsg(null, c, data, opt);
    }

    public Task<ReceiveMsg> SendAsync(SendMsg msg)
    {
        if (msg.useHttp)
        {
            return isolate.sender.SendHttpAsync(msg);
        }
        else
        {
            return isolate.sender.SendAsync(msg);
        }
    }

    public async Task<ReceiveMsg<TResp>> SendAsync<TResp>(SendMsg msg) where TResp : RespBase, new()
    {
        var resp = await SendAsync(msg);
        return new ReceiveMsg<TResp>(resp);
    }

    public void Send(SendMsg msg)
    {
        isolate.sender.Send(msg);
    }
}