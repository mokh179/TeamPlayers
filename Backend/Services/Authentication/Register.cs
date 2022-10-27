


namespace Services.Authentication
{
    public class Register :BaseAuthentication, IRegisterAuthenticate
    {
        private IGenerateToken _generateToken;
        public Register(IGenerateToken generateToken,UserManager<User> user, IOptions<JWT> jwt, AppDbContext db, RoleManager<IdentityRole> role) : base(user, jwt, db, role)
        {
            _generateToken = generateToken;
        }

        public async Task<AuthenticationDTO> RegisterAsync(RegisterDTO rm)
        {
            if (await _user.FindByEmailAsync(rm.Email) != null)
                return new AuthenticationDTO { Message = "E-mail already Existed" };
            if (await _user.FindByNameAsync(rm.Username) != null)
                return new AuthenticationDTO { Message = "UserName already Existed" };
            var user = new User()
            {
                FirstName = rm.Firstname,
                LastName = rm.Lastname,
                Email = rm.Email,
                UserName = rm.Username,
               
            };
            var result = await _user.CreateAsync(user, rm.Password);
            if (!result.Succeeded)
            {
                var errs = "";
                foreach (var item in result.Errors)
                {
                    errs = $"{item.Description} , ";
                }
                return new AuthenticationDTO { Message = errs };
            }
            var token = await _generateToken.Generatetoken(user);
            await _user.AddToRoleAsync(user, "User");

            return new AuthenticationDTO
            {
                email = user.Email,
                Tokenlife = token.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = user.UserName,
                userID = user.Id,
            };
        }
    }
}
