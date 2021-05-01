using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AppWithTemplate.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Web_Resume.Model.DataContext;
using Web_Resume.Model.Entity.Membership;
using Web_Resume;
using Web_Resume.Controllers;

namespace AppWithTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly ResumeDbContext _context;
        private readonly RoleManager<ResumeRole> roleManager;

        public RolesController(ResumeDbContext context, RoleManager<ResumeRole> roleManager)
        {
            _context = context;
            this.roleManager = roleManager;
        }

        // GET: Admin/Roles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        // GET: Admin/Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organiRole = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organiRole == null)
            {
                return NotFound();
            }

            var roleModel = new RoleViewModel();
            roleModel.Role = organiRole;

            string[] appliedPrincipals =
             _context.RoleClaims.Where(u => u.RoleId == organiRole.Id && u.ClaimValue.Equals("1")).Select(u =>
            u.ClaimType)
             .ToArray();


            foreach (var principal in Startup.principals)
            {
                roleModel.Principals.Add(principal, Array.IndexOf(appliedPrincipals, principal) != -1);
            }


            return View(roleModel);
        }

        // GET: Admin/Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] ResumeRole organiRole)
        {
            if (ModelState.IsValid)
            {
                await roleManager.CreateAsync(organiRole);
                return RedirectToAction(nameof(Index));
            }
            return View(organiRole);
        }

        // GET: Admin/Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organiRole = await _context.Roles.FindAsync(id);
            if (organiRole == null)
            {
                return NotFound();
            }
            return View(organiRole);
        }

        // POST: Admin/Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp")] ResumeRole organiRole)
        {
            if (id != organiRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organiRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganiRoleExists(organiRole.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(organiRole);
        }

        // GET: Admin/Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organiRole = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organiRole == null)
            {
                return NotFound();
            }

            return View(organiRole);
        }

        // POST: Admin/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organiRole = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(organiRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Policy = "admin.roles.setpolicy")]
        public async Task<IActionResult> SetPolicy(int roleId, bool selected, string policyName)
        {
            var role = await roleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Istifadeci tapilmadi"
                });
            }


            if (selected)
            {
                if (_context.RoleClaims.Any(uc => uc.RoleId == roleId && uc.ClaimType.Equals(policyName)))
                {
                    return Json(new
                    {
                        error = true,
                        message = "Bu selahiyyet artiq var"
                    });
                }

                _context.RoleClaims.Add(new ResumeRoleClaim
                {
                    RoleId = role.Id,
                    ClaimType = policyName,
                    ClaimValue = "1"
                });
                await _context.SaveChangesAsync();

                return Json(new
                {
                    error = false,
                    message = $"{role.Name} ucun {policyName} selahiyyeti tetbiq olundu"
                });
            }
            else
            {
                var currentClaim = await _context.RoleClaims
                    .AsNoTracking()
                    .FirstOrDefaultAsync(uc => uc.RoleId == role.Id && uc.ClaimType.Equals(policyName)
                    && uc.ClaimValue.Equals("1"));



                if (currentClaim == null)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Bu selahiyyet movcud deyil"
                    });
                }

                _context.RoleClaims.Remove(currentClaim);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    error = false,
                    message = $"{role.Name} ucun {policyName} selahiyyeti legv olundu"
                });
            }


            return View();
        }

        private bool OrganiRoleExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
