using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Resume.Model.Entity
{
    public class SkillCategory:BaseEntity
    {
        public int? ParentId { get; set; }
        public virtual SkillCategory Parent { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SkillCategory> Children { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
