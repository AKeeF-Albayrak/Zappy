using Identity.Application.Abstractions.Repositories;
using Identity.Application.Abstractions.Services;
using Identity.Domain.Entities;
using MediatR;
using SharedKernel.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Features.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;
        public LoginCommandHandler(IUserReadRepository userReadRepository, IPasswordHasher passwordHasher, ITokenService tokenService, IUnitOfWork unitOfWork, IRefreshTokenWriteRepository refreshTokenWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _refreshTokenWriteRepository = refreshTokenWriteRepository;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.UsernameOrEmail) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return new LoginCommandResponse
                {
                    Succeeded = false,
                    ErrorCode = "AUTH_EMPTY_CREDENTIALS",
                    Message = "Kullanıcı adı/email ve şifre boş olamaz."
                };
            }

            var user = await _userReadRepository.GetUserByLoginConfAsync(
                request.UsernameOrEmail,
                _passwordHasher.Hash(request.Password));

            if (user is null)
            {
                return new LoginCommandResponse
                {
                    Succeeded = false,
                    ErrorCode = "AUTH_INVALID_CREDENTIALS",
                    Message = "Kullanıcı adı/email veya şifre hatalı."
                };
            }

            if (!user.IsActive)
            {
                return new LoginCommandResponse
                {
                    Succeeded = false,
                    ErrorCode = "AUTH_USER_PASSIVE",
                    Message = "Kullanıcı hesabı aktif değil."
                };
            }


            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshTokenValue = _tokenService.GenerateRefreshToken();

            var refreshToken = new RefreshToken
            {
                UserId = user.Id,
                Token = refreshTokenValue,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            await _refreshTokenWriteRepository.AddAsync(refreshToken, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new LoginCommandResponse
            {
                Succeeded = true,
                Message = "Giriş başarılı.",
                UserId = user.Id,
                AccessToken = accessToken,
                RefreshToken = refreshTokenValue
            };
        }
    }
}
