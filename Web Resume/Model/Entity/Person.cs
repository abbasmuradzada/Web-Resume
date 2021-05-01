using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Resume.Model.Entity
{
    public class Person:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string ExperienceInfo { get; set; }
        [Required]
        public int DegreeId { get; set; }
        public virtual Degree Degree { get; set; }
        [Required]
        public int CareerLevelId { get; set; }
        public virtual CareerLevel CareerLevel { get; set; }

        [Required]
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string CvPdfPath { get; set; }
        public string CvWordPath { get; set; }
        public string FacebookLink { get; set; }
        public string GoogleLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedinLink { get; set; }
        public string SkypeLink { get; set; }

        [Required]
        public string Info { get; set; }
        public string BioInfo { get; set; }
        public string BioDesc { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Avialable { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<PersonServiceItem> Services { get; set; }
        public virtual ICollection<PersonSkillItem> Skills { get; set; }
    }
}
