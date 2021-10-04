using DownWallet.Services.DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DownWallet.Services.Jwt
{
    public class JwtService
    {
        public static string Encode(WalletOwnerDto walletOwnerDto)
        {
            var secretKey = Encoding.UTF8.GetBytes("YourSecretKeyHere");
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256Signature);
            var claims = _getClaims(walletOwnerDto);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "YourWebsite",
                Audience = "YourWebsite",
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddSeconds(1),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(claims)
            };

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();


            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);
            var jwt = tokenHandler.WriteToken(securityToken);
            return jwt;
        }
        public static JwtSecurityToken Decode(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt);
            var tokenS = jsonToken as JwtSecurityToken;

            //var handler = new JwtSecurityTokenHandler();
            //var jwtSecurityToken = handler.ReadJwtToken(jwt);

            return tokenS;
        }
        private static IEnumerable<Claim> _getClaims(WalletOwnerDto walletOwnerDto)
        {
            var list = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, walletOwnerDto.Id.ToString()),
                new Claim(ClaimTypes.Name, walletOwnerDto.Username),
                new Claim(ClaimTypes.Email, walletOwnerDto.Email),
                new Claim(ClaimTypes.Role, walletOwnerDto.Role.Name)
            };
            return list;
        }
    }
}
