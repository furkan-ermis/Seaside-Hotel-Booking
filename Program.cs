using DestinyHaven.Data;
using DestinyHaven.Entity;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace DestinyHaven
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

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
            
            app.MapControllerRoute(
            name: "default",
            pattern: "{area=Guest}/{controller=Home}/{action=Index}/{id?}"
            );
            app.MapControllerRoute(
             name: "areas",
             pattern: "{area:exists}/{controller=User}/{action=Index}/{id?}"
           );
            app.Run();
        }
    }
}