using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Resume.Model.Entity
{
    public class PersonServiceItem
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
