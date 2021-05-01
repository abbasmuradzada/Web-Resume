using System.Collections.Generic;
using Web_Resume.Model.Entity.Membership;

namespace Web_Resume.Controllers
{
    public class RoleViewModel
    {
        public ResumeRole Role { get; set; }

        public Dictionary<string, bool> Principals { get; set; } = new Dictionary<string, bool>();
    }
}
