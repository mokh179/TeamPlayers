using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication
{
    public class Login : BaseAuthentication,ILoginAuthenticate
    {
        private IGenerateToken _generateToken;

        public Login(IGenerateToken generateToken,UserManager<User> user, IOptions<JWT> jwt, AppDbContext db, RoleManager<IdentityRole> role) : base(user, jwt, db, role)
        {
            _generateToken = generateToken;
        }

        public async Task<AuthenticationDTO> LogInAsync(LoginDTO lm)
        {
            var user = lm.Username.Contains('@') ? await _user.FindByEmailAsync(lm.Username) : await _user.FindByNameAsync(lm.Username);

            var ValidPassword = await _user.CheckPasswordAsync(user, lm.Password);
                if (user == null || !ValidPassword)
                {
                    return new AuthenticationDTO { Message = "Invalid Username or Password" };

                }
                else
                {
                    var token = await _generateToken.Generatetoken(user);

                    var userID = await _db.Users.Where(a => a.UserName == lm.Username).Select(a => a.Id).FirstOrDefaultAsync();
                    var RoleID = await _db.UserRoles.Where(a => a.UserId == userID).Select(a => a.RoleId).FirstOrDefaultAsync();
                    
                    var role = _db.Roles.Where(a => a.Id == RoleID).Select(a => a.Name);
                    var Token = new JwtSecurityTokenHandler().WriteToken(token);
                  
                    AuthenticationDTO auth = new AuthenticationDTO
                    {
                        Username = user.UserName,
                        Email = user.Email,
                        Tokenlife = token.ValidTo,
                        IsAuthenticated = true,
                        Roles = await _db.Roles.Where(a => a.Id == RoleID).Select(a => a.Name).ToListAsync(),
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        userID = user.Id,
                    };

                    return auth;
                }
            
        }
    }
}
