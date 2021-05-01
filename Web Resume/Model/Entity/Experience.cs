using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Resume.Model.Entity
{
    public class Experience: BaseEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public string ImagePath { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
