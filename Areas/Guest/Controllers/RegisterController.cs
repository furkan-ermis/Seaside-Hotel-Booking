using DestinyHaven.Entity;
using DestinyHaven.GenericModels;
using DestinyHaven.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Configuration;

namespace DestinyHaven.Areas.Guest.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager; 
        private readonly IConfiguration _configuration;

        public RegisterController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;


        }
        public async Task<IActionResult> Register()
        {
            AppUserRegisterViewModel appUserRegisterViewModel = RoleSelectBox();
            return View(appUserRegisterViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterViewModel appUserRegisterViewModel)
        {
            await GenerateDefaultRolesAsync();
            var existingUser = await _userManager.FindByEmailAsync(appUserRegisterViewModel.Email);
            if (existingUser != null)
            { 
                ModelState.AddModelError("Email", "Bu e-posta adresi zaten kullanılmaktadır.");
                appUserRegisterViewModel = RoleSelectBox();
                return View(appUserRegisterViewModel);
            }

            if (ModelState.IsValid)
            {
                var code =RandomCodeGenerate.GenerateSecureRandomCode(6);
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
                    if (string.IsNullOrWhiteSpace(appUser.Role))
                    {
                        await _userManager.AddToRoleAsync(appUser, DefaultRole.RoleUser);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(appUser, appUser.Role);
                    }
                    // Pass IConfiguration to SendMail constructor
                    new SendMail(_configuration, appUser.Email,"Admin", "User", "Destiny Haven Onay Kodu", "Kayıt olmak için onay kodunuz : " + appUser.ConfirmCode);
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
        private async Task GenerateDefaultRolesAsync()
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
        private AppUserRegisterViewModel RoleSelectBox()
        {
            return new AppUserRegisterViewModel()
            {
                RoleList = _roleManager.Roles
                             .Select(x => x.Name)
                             .Select(u => new SelectListItem
                             {
                                 Text = u,
                                 Value = u
                             })
            };
        }

    }
}
