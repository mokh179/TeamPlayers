using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Services.Context;
using System;
using Microsoft.AspNetCore.Authorization;

using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Services.Authentication.JWTToken
{
    public  class GenerateToken:BaseAuthentication, IGenerateToken
    {
        public GenerateToken(UserManager<User> user, IOptions<JWT> jwt, AppDbContext db, RoleManager<IdentityRole> role) : base(user, jwt, db, role)
        {
        }

        public  async Task<JwtSecurityToken> Generatetoken(User user)
        {
            var Userclaims = await _user.GetClaimsAsync(user); //get user claims
            var Userroles = await _user.GetRolesAsync(user); //get user rols
            var Roleclaims = new List<Claim>();
            foreach (var item in Userroles)
            {
                Roleclaims.Add(new Claim("roles", item));
            }
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //New ID for each claim
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim("uid", user.Id)
            }.Union(Userclaims).Union(Roleclaims);
            var symmetrickey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingcredentials = new SigningCredentials(symmetrickey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
             issuer: _jwt.Issuer,
             audience: _jwt.Audience,
             claims: claims,
             expires: DateTime.Now.AddDays(_jwt.DurationInDay),
             signingCredentials: signingcredentials);
            return jwtSecurityToken;
        }
    }
}
