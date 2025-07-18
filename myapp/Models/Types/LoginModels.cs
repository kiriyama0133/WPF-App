using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp.Models.Types;

public class LoginRequest
{
    public string identifier { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
}
public class LoginResponse
{
    public string message { get; set; } = string.Empty;
    public string token { get; set; } = string.Empty;
    public User user { get; set; } = new User();
}

