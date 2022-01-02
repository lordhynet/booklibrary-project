using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PersonalProjectBookLibraryApi.Model;
using PersonalProjectBookLibraryApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PersonalProjectBookLibraryApi.Services
{
    public class JwtServices : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtServices(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(AppUser user, List<string> userRoles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, $"{user.Email}"),
            };
            foreach (var roles in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, roles));
            }

            var symmetricSecurityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:SecretKey").Value));
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Today.AddDays(7),
                SigningCredentials =
                    new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);


        }
    }
}
