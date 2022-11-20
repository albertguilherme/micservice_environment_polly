using auth_mic_service.Data.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using auth_mic_service.Services.Interface;
using auth_mic_service.Repository.Interface;
using Microsoft.Extensions.Options;
using auth_mic_service.Extensions;

namespace auth_mic_service.Services.Impl
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ITokenRepository _tokenRepository;

        public TokenService(IOptionsMonitor<JwtSettings> jwtSettings, ITokenRepository tokenRepository)
        {
            _jwtSettings = jwtSettings.CurrentValue;
            _tokenRepository = tokenRepository;
        }

        public Token CreateUserToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    user.Roles.Select(x => new Claim(ClaimTypes.Role, x.Acronyms))
                    .Append(new Claim(ClaimTypes.Name, user.Name))
                    .Append(new Claim(ClaimTypes.GivenName, user.FirstName))
                    .Append(new Claim(ClaimTypes.Email, user.Email))
                ),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var createdToken = tokenHandler.WriteToken(token);

            var tokenModel = new Token()
            {
                User = user,
                Value = createdToken,
                ValidFrom = token.ValidFrom,
                ValidTo = token.ValidTo
            };

            _tokenRepository.Add(tokenModel);
            _tokenRepository.SaveChanges();

            return tokenModel;
        }
    }
}
