using DestinyHaven.Entity;
using DestinyHaven.GenericModels;
using DestinyHaven.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DestinyHaven.Areas.Guest.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegisterController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async Task<IActionResult> Register()
        {
            await GenerateDefaultRoles();
            AppUserRegisterViewModel appUserRegisterViewModel = new AppUserRegisterViewModel()
            {
                RoleList = _roleManager.Roles
                 .Select(x => x.Name)
                 .Select(u => new SelectListItem
                 {
                     Text = u,
                     Value = u
                 })   
            };
            return View(appUserRegisterViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterViewModel appUserRegisterViewModel)
        {
            Random rnd = new Random();
            if (ModelState.IsValid)
            {
                int code;
                code = rnd.Next(100000, 1000000);
                AppUser appUser = new AppUser()
                {
                    Name = appUserRegisterViewModel.Name,
                    Email = appUserRegisterViewModel.Email,
                    Surname = appUserRegisterViewModel.Surname,
                    UserName = appUserRegisterViewModel.Username,
                    ImageUrl = "/image/user/default.jpg",
                    District = "Turkey",
                    City = "Istanbul",
                    ConfirmCode = code,
                    Role = appUserRegisterViewModel.Role
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterViewModel.Password);
                if (result.Succeeded)
                {
                   
                    if (appUser.Role == null)
                    {
                        await _userManager.AddToRoleAsync(appUser, DefaultRole.RoleUser);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(appUser, appUser.Role);
                    }


                    // ! SendMail Generic Method send mail to user
                    new SendMail(appUser.Email, "10webapp10@gmail.com", "mnvvwljcchhtsaig",
                       "Destiny Haven Otel Rezervasyon ", "User", "Destiny Haven Onay Kodu", "Kayıt olmak için onay kodunuz : " + appUser.ConfirmCode);
                    TempData["Mail"] = appUserRegisterViewModel.Email;
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
        private async Task GenerateDefaultRoles()
        {
            if (!await _roleManager.RoleExistsAsync(DefaultRole.RoleAdmin))
            {
                await _roleManager.CreateAsync(new IdentityRole(DefaultRole.RoleAdmin));
            }
            if (!await _roleManager.RoleExistsAsync(DefaultRole.RoleUser))
            {
                await _roleManager.CreateAsync(new IdentityRole(DefaultRole.RoleUser));
            }
            if (!await _roleManager.RoleExistsAsync(DefaultRole.RoleGuest))
            {
                await _roleManager.CreateAsync(new IdentityRole(DefaultRole.RoleGuest));
            }
        }
    }
}
