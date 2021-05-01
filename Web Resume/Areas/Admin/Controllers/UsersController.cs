using AppWithTemplate;
using AppWithTemplate.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Resume;
using Web_Resume.Model.DataContext;
using Web_Resume.Model.Entity.Membership;

namespace AppWithTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly ResumeDbContext _context;
        private readonly UserManager<ResumeUser> userManager;

        public UsersController(ResumeDbContext context, UserManager<ResumeUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        [Authorize(Policy = "admin.users.index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }


        [Authorize(Policy = "admin.users.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organiUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organiUser == null)
            {
                return NotFound();
            }


            var viewModel = new UserViewModel();
            viewModel.User = organiUser;



            string[] appliedPrincipals =
                _context.UserClaims.Where(u => u.UserId == organiUser.Id && u.ClaimValue.Equals("1")).Select(u =>
            u.ClaimType)
                .ToArray();


            foreach (var principal in Startup.principals)
            {
                viewModel.Principals.Add(principal, Array.IndexOf(appliedPrincipals, principal) != -1);
            }


            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Policy = "admin.users.setpolicy")]
        public async Task<IActionResult> SetPolicy(int userId, bool selected, string policyName)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Istifadeci tapilmadi"
                });
            }


            if (selected)
            {
                if (_context.UserClaims.Any(uc => uc.UserId == userId && uc.ClaimType.Equals(policyName)))
                {
                    return Json(new
                    {
                        error = true,
                        message = "Bu selahiyyet artiq var"
                    });
                }

                _context.UserClaims.Add(new ResumeUserClaim
                {
                    UserId = user.Id,
                    ClaimType = policyName,
                    ClaimValue = "1"
                });
                await _context.SaveChangesAsync();

                return Json(new
                {
                    error = false,
                    message = $"{user.UserName} ucun {policyName} selahiyyeti tetbiq olundu"
                });
            }
            else
            {
                var currentClaim = await _context.UserClaims
                    .AsNoTracking()
                    .FirstOrDefaultAsync(uc => uc.UserId == user.Id && uc.ClaimType.Equals(policyName)
                    && uc.ClaimValue.Equals("1"));



                if (currentClaim==null)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Bu selahiyyet movcud deyil"
                    });
                }

                _context.UserClaims.Remove(currentClaim);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    error = false,
                    message = $"{user.UserName} ucun {policyName} selahiyyeti legv olundu"
                });
            }


            return View();
        }
    }
}
