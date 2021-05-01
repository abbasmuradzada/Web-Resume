using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Web_Resume.Extentions;
using Web_Resume.Helpers;
using Web_Resume.Model.DataContext;
using Web_Resume.Model.Entity;

namespace Web_Resume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly ResumeDbContext _db;
        private readonly IWebHostEnvironment _env;
        public PostController(ResumeDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_db.Posts.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post posts)
        {
            if (!ModelState.IsValid) return View();
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!posts.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }

            if (posts.Photo.MaxLength(2000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return View();
            }

            if (_db.Posts.Count() >= 4)
            {
                return RedirectToAction(nameof(Index));
            }
            string path = Path.Combine("Assets", "images", "post");
            string fileName = await posts.Photo.SaveImg(_env.WebRootPath, path);
            Post newStatus = new Post();
            newStatus.Image = fileName;
            newStatus.Title = posts.Title;
            newStatus.Desc = posts.Desc;
            newStatus.CreatedDate = DateTime.Now;
            _db.Posts.Add(newStatus);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Post posts = _db.Posts.FirstOrDefault(x => x.Id == id);
            if (posts == null) return NotFound();
            _db.Posts.Remove(posts);
            string path = Path.Combine("Assets", "images", "post");
            Helper.DeleteImage(_env.WebRootPath, path, posts.Image);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
