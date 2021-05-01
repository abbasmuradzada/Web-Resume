using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Resume.Model.Entity
{
    public class Skill: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Score { get; set; }
        public virtual int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual SkillCategory SkillCategory { get; set; }
    }
}
