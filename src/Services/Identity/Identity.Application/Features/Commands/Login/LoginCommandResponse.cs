using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Features.Commands.Login
{
    public class LoginCommandResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public string ErrorCode { get; set; }
    }
}
