using Developers2023.Application.Interfaces;
using Developers2023.Common.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Developers2023.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly TokenOption _tokenOption;

        public AuthService(IOptions<TokenOption> tokenOption)
        {
            _tokenOption = tokenOption.Value;
        }

        public string GetToken(string login, string password)
        {
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"{_tokenOption.LeftKeySecret}{_tokenOption.RightKeySecret}"));
            SigningCredentials signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken tokenOptions = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                audience: _tokenOption.Audience,
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(_tokenOption.Expires),
                signingCredentials: signinCredentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
    }
}
