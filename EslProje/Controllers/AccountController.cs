using EslProje.Models.Auth;
using EslProje.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EslProje.Controllers
{
    public class AccountController : Controller
    {
       private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid) return View(registerVM);
         
            AppUser appUser = new AppUser()
            {
                Name = registerVM.Name,
                Email = registerVM.Email,

            };
            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

            /////appuser tablesine sorgunu at yeni yarat
            ///

            /////eyer dataya sorgu yanlis gelibse meselen password hissesinde 8 yox 6 reqem yazilibsa
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            return View(registerVM);
            }


            return RedirectToAction(nameof(Register));
        }
    }
}
