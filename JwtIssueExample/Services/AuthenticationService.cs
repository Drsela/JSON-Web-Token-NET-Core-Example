using JwtIssueExample.Models;
using JwtIssueExample.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using JwtIssueExample.DTO;

namespace JwtIssueExample.Services
{
    public class AuthenticationService
    {
        private UserRepository _repository;
        private IConfiguration _configuration;

        public AuthenticationService(UserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }
        public async Task<string> Login(UserDTO user)
        {
            var dbUser = await _repository.GetUser(user.UserName, user.Password);
            var jwt = GenerateJwt(dbUser);
            return jwt;
        }

        private string GenerateJwt(User user)
        {
            var key = _configuration.GetValue<string>("jwt-signing-key");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Type.ToString()),
                },
                expires: DateTime.Now.AddHours(24),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
