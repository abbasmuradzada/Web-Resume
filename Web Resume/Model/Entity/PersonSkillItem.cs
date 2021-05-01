using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Resume.Model.Entity
{
    public class PersonSkillItem
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
