using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public partial class OPay_NewOrderFinishNotify: RespBase {
    public OPay_NewOrderFinishNotify() {
    }
    
    public string orderId = string.Empty;
}