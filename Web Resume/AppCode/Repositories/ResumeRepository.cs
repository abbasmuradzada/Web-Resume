using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Resume.Model.DataContext;

namespace Web_Resume.AppCode.Repositories
{
    public class ResumeRepository
    {
        readonly ResumeDbContext db;
        public ResumeRepository(ResumeDbContext db)
        {
            this.db = db;
        }
        //public ResumeDbContext = db.Resumes
    }
}
