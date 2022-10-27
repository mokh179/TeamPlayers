
namespace Services.Authentication
{
    public class BaseAuthentication
    {
        public readonly JWT _jwt;
        public readonly UserManager<User> _user;
        public readonly AppDbContext _db;
        public readonly RoleManager<IdentityRole> _role;
        public BaseAuthentication(UserManager<User> user, IOptions<JWT> jwt, AppDbContext db, RoleManager<IdentityRole> role)
        {
            _user = user;
            _jwt = jwt.Value;
            _db = db;
            _role = role;
        }
    }
}
