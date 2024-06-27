using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

/// <summary>
/// 创建支付订单
/// <summary>
public partial class Pay_CreateOrder: ReqBase {
    public Pay_CreateOrder() {
    }
    
    /// <summary>
    /// 商品id
    /// <summary>
    public string goodsId;
}