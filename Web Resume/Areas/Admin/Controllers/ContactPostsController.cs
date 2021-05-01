using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Web_Resume.Model.DataContext;

namespace Web_Resume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactPostsController : Controller
    {
        private readonly ResumeDbContext db;
        public ContactPostsController(ResumeDbContext db)
        {
            this.db = db;
        }

        [Authorize("admin.contactposts.index")]
        public async Task<IActionResult> Index()
        {
            var data = await this.db.ContactPosts.ToListAsync();
            return View(data);
        }

        [Authorize("admin.contactposts.answer")]
        public async Task<IActionResult> Answer(int id)
        {
            if (id<=0)
            {
                return BadRequest();
            }
            var data = await db.ContactPosts.FirstOrDefaultAsync(c=>c.AnswerByUser == null && c.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        [Authorize("admin.contactposts.answer")]
        public async Task<IActionResult> Answer(int id, string AnswerContent)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var data = await db.ContactPosts.FirstOrDefaultAsync(c => c.AnswerByUser == null && c.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(AnswerContent))
            {
                ModelState.AddModelError("AnswerContent", "Doldurulmayib");
                return View(data);
            }

            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier)).Value);

            data.AnswerContent = AnswerContent;
            data.AnswerDate = DateTime.UtcNow.AddHours(4);
            data.CreatedByUserId = userId;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            client.Credentials = new NetworkCredential("abbasmuradzada@gmail.com", "Abbas@123");
            client.EnableSsl = true;

            MailMessage message = new MailMessage
            {
                Subject = $"Webesume - {data.Subject}",
                From = new MailAddress("abbasmuradzada@gmail.com"),
                IsBodyHtml = true,
                Body = data.AnswerContent
            };

            message.To.Add(data.Email);
            client.Send(message);

            await db.SaveChangesAsync();
            TempData["Message"] = "Gonderildi";

            return RedirectToAction(nameof(Index));
        }
    }
}
