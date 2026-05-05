using Identity.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Features.Commands.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public Platforms Platform { get; set; }
    }
}
