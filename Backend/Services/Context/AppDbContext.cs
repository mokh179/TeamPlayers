


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Services.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       
    }
}
