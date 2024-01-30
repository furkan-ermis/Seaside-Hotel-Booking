using DestinyHaven.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DestinyHaven.Data
{
    public class Context : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;initial catalog=DestinyHavenDb;integrated Security=true");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<UserAddress>? UserAddresses { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Gallery>? Galleries { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Facility>? Facilities { get; set; }
        public DbSet<RoomFacility>? RoomFacilities { get; set; }
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<RoomDetail>? RoomDetails { get; set; }
        public DbSet<Testimonial>? Testimonials { get; set; }
        
    }
}
