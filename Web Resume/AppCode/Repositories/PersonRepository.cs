using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Resume.Model.DataContext;
using Web_Resume.Model.Entity;

namespace Web_Resume.AppCode.Repositories
{
    public class PersonRepository
    {
        readonly ResumeDbContext db;
        public PersonRepository(ResumeDbContext db)
        {
            this.db = db;
        }
        public Person GetCurrentPerson()
        {
            var person = db.People
                .Include(p=>p.Degree)
                .Include(p=>p.CareerLevel)
                .FirstOrDefault(predicate => predicate.DeletedDate == null);
            return person;
        }
    }
}
