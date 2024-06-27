using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hortor.O4e.Data;
using Hortor.O4e.Rpc;
using Hortor.Bon;
public partial class IsolatePayService : ServiceBase
{
    public IsolatePayService(Isolate isolate) : base(isolate)
    {
    }
    /// <summary>
    /// 创建支付订单
    /// <summary>
    public Task<ReceiveMsg<Pay_CreateOrderR>> CreateOrder(Pay_CreateOrder data, CmdOption opt = default)
	{
        return SendAsync<Pay_CreateOrderR>(ToSendMsg("pay_createorder", data, opt));
    }
}

public partial class PayService
{
    /// <summary>
    /// 创建支付订单
    /// <summary>
    public static Task<ReceiveMsg<Pay_CreateOrderR>> CreateOrder(Pay_CreateOrder data, CmdOption opt = default)
	{
        return Isolate.Default.PayService.CreateOrder(data, opt);
    }
}


