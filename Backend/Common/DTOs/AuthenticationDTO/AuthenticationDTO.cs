using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.AuthenticationDTO
{
    public class AuthenticationDTO : IdentityUser
    {
        public string Message { get; set; }
        public string Username { get; set; }
        public string userID { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public DateTime Tokenlife { get; set; }
        public bool IsAuthenticated { get; set; }
        
    }
}
