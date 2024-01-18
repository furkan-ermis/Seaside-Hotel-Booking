using DestinyHaven.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DestinyHaven.Data
{
    public class Context : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;initial catalog=DestinyHavenDb;integrated Security=true");
        }
        public DbSet<UserAddress>? UserAddresses { get; set; }
    }
}
