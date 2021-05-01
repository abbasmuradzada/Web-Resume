using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_Resume.Model.Entity.Membership;

namespace Web_Resume.Model.Entity
{
    public class ContactPost: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime? AnswerDate { get; set; }
        public string AnswerContent { get; set; }
        public virtual ResumeUser AnswerByUser { get; set; }
    }
}
