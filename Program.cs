using DestinyHaven.Data;
using DestinyHaven.Entity;
using DestinyHaven.Services;
using DestinyHaven.Services.Interface;
using DestinyHaven.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace DestinyHaven
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            // ! Identity
            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            { 
                options.SignIn.RequireConfirmedAccount = false; 
                options.Password.RequireNonAlphanumeric = false; 
            })
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();
            // ! --------
            // ! Services
            builder.Services.AddTransient<IRoomService, RoomService>();
            builder.Services.AddTransient<IBookingService, BookingService>();
            builder.Services.AddTransient<IHomeService, HomeService>();
            // 
            // ! --------
            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            // ! Identity // Authorization dan önce olmalý
            app.UseAuthentication();
            // ! --------
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            
            app.MapControllerRoute(
            name: "default",
            pattern: "{area=Guest}/{controller=Home}/{action=Index}/{id?}"
            );
            app.MapControllerRoute(
             name: "areas",
             pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
           );

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<Context>();

                    if (!context.Users.Any(u => u.Email == "10webapp10@gmail.com"))
                    {
                        var userManager = services.GetRequiredService<UserManager<AppUser>>();

                        var adminUser = new AppUser
                        {
                            Name = "Admin",
                            Email = "10webapp10@gmail.com",
                            Surname = "admin",
                            UserName = "admin",
                            ImageUrl = "/image/user/default.jpg",
                            District = "Turkey",
                            City = "Istanbul",
                            Role = "admin",
                            EmailConfirmed = true

                        };

                        var result =  userManager.CreateAsync(adminUser, "123123Aa").Result;
                             userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }


            app.Run();
        }
    }
}