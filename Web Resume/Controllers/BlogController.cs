using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Web_Resume.Model.DataContext;

namespace Web_Resume.Controllers
{
    public class BlogController : Controller
    {
        private readonly ResumeDbContext _db;
        public BlogController(ResumeDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Posts.ToList());
        }

        public IActionResult Details(int? id)
        {
            return View();
        }

    }
}
