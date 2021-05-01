using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web_Resume.Extentions;
using Web_Resume.Model.Entity.Membership;
using Web_Resume.Model.FormModels;

namespace Web_Resume.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        readonly SignInManager<ResumeUser> signInManager;
        readonly UserManager<ResumeUser> userManager;
        public AccountController(SignInManager<ResumeUser> signInManager,
            UserManager<ResumeUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(UserFormModel model)
        {
            ResumeUser user = null;

            if (model.UserName.IsEmail())
            {
                user = await userManager.FindByEmailAsync(model.UserName);
            }
            else
            {
                user = await userManager.FindByNameAsync(model.UserName);
            }

            if (user == null)
            {
                ModelState.AddModelError("UserName", "Istifadeci adi ve ya sifre sehdir");
            }

            if (user != null && !user.EmailConfirmed)
            {
                ModelState.AddModelError("UserName", "Email Hesabinizi tesdiq edin");
            }



            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, true, true);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", routeValues: new
                    {
                        area = ""
                    });
                }
                else
                {
                    ModelState.AddModelError("UserName", "Istifadeci adi ve ya sifre sehdir");
                }

            }


            return View(model);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
