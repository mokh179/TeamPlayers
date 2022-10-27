using Core.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IAuthentication
{
    public interface IGenerateToken
    {
        public  Task<JwtSecurityToken> Generatetoken(User user);

    }
}
