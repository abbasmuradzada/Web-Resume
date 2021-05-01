using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Resume.Model.DataContext;
using Web_Resume.Model.Entity;
using Web_Resume.Model.FormModels;

namespace Web_Resume.Controllers
{
    public class HomeController : Controller
    {
        readonly ResumeDbContext db;
        public HomeController(ResumeDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var people = db.People
                .Include(p => p.Degree)
                .Include(p => p.CareerLevel)
                .Include(p=>p.Services).ThenInclude(s=>s.Service)
                .FirstOrDefault(p => p.DeletedDate == null);
            return View(people);
        }
        public async Task<IActionResult> Resume()
        {
            var bio = await db.People
                .Include(p => p.Experiences)
                .Include(p => p.Skills)
                .ThenInclude(s=> s.Skill)
                .ThenInclude(s=> s.SkillCategory)
                .ThenInclude(c=> c.Parent)
                .FirstOrDefaultAsync(p => p.DeletedDate == null);
            return View(bio);
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    error = true,
                    message = "data Problemi",
                    errors = (object)null   
                });
            }

            try
            {
                ContactPost post = new ContactPost();
                post.Name = model.Name;
                post.Email = model.Email;
                post.Subject = model.Subject;
                post.Content = model.Content;

                db.ContactPosts.Add(post);
                await db.SaveChangesAsync();
                return Json(new
                {
                    error = false,
                    message = "Muracietiniz ugurla qeyde alindi"
                });
            }
            catch (System.Exception)
            {
                return Json(new
                {
                    error = true,
                    message = "Check Later Again"
                });
            }
        }
    }
}
