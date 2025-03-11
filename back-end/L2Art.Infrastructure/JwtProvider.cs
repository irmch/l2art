using L2Art.Application.Abstractions;
using L2Art.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure
{
    public class JwtProvider(IOptions<JwtOptions> jwtOptions) : IJwtProvider
    {
        private readonly JwtOptions _options = jwtOptions.Value;

        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString())];

            Console.WriteLine(_options);

            var signinCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                    SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signinCredentials,
                expires: DateTime.UtcNow.AddDays(_options.ExpiresDays));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
