using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Resume.Model.Entity.Membership;

namespace AppWithTemplate.Areas.Admin.Models.ViewModels
{
    public class UserViewModel
    {
        public ResumeUser User { get; set; }

        public Dictionary<string, bool> Principals { get; set; } = new Dictionary<string, bool>();
    }
}
