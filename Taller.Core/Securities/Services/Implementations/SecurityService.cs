using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Taller.Core.Securities.Entities;

namespace Taller.Core.Securities.Services.Implementations
{
    public class SecurityService : ISecurityService
    {
        public string HasPassword(string userName, string hashedPassword)
        {
            PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

            return passwordHasher.HashPassword(userName, hashedPassword);

        }


        public bool VerifyHashedPassword(string userName, string hasePassword, string providerPassword)
        {

            PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(userName, hasePassword, providerPassword);

            if (result == PasswordVerificationResult.Success) return true;


            return false;
        }



        public SecurityEntity JwtSecutiry(string jwtSecrectKey)
        {
            DateTime utcNow = DateTime.UtcNow;

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString()),
            };

            DateTime expireDateTime = utcNow.AddDays(1);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //Key = credentials

            byte[] key = Encoding.ASCII.GetBytes(jwtSecrectKey);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key);
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: expireDateTime,
                notBefore: utcNow,
                signingCredentials: signingCredentials
                );

            string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new SecurityEntity()
            {
                TokenType = "Bearer",
                AccesToken = token,
                ExpireOn = expireDateTime
            };

        }
    }
}
