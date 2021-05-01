using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Resume.Model.Entity
{
    public class Service: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconClass { get; set; }
        public virtual ICollection<PersonServiceItem> People { get; set; }
    }
}
