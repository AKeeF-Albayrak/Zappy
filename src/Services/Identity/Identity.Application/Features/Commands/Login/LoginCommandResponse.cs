using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Features.Commands.Login
{
    public class LoginCommandResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
    }
}
