using System;
using System.Collections.Generic;
using Hortor.O4e.Data;

public partial class Login_AuthUserR: RespBase {
    public Login_AuthUserR() {
    }
    
    public GDUser user;
    public string roleToken = string.Empty;
    public long roleId = 0;
}