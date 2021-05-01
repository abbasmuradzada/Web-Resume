using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Resume.Model.Entity;
using Web_Resume.Model.Entity.Membership;

namespace Web_Resume.Model.DataContext
{
    public class ResumeDbContext: IdentityDbContext<ResumeUser, ResumeRole, int, ResumeUserClaim, ResumeUserRole, ResumeUserLogin, ResumeRoleClaim, ResumeUserToken>
    {
        public ResumeDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<CareerLevel> CareerLevel { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<AcademicBg> AcademicBgs { get; set; }
        public DbSet<PersonServiceItem> PersonServiceCollection { get; set; }
        public DbSet<SkillCategory> SkillCategory { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<PersonSkillItem> PersonSkillCollection { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ContactPost> ContactPosts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonServiceItem>(e => {
                e.HasKey(k => new
                {
                    k.PersonId,
                    k.ServiceId
                });
                e.ToTable("PersonServiceCollection");
            });

            modelBuilder.Entity<PersonSkillItem>(e => {
                e.HasKey(k => new
                {
                    k.PersonId,
                    k.SkillId
                });
                e.ToTable("PersonSkillCollection");
            });

            modelBuilder.Entity<ResumeUser>(e =>
            {
                e.ToTable("Users", "Membership");
            });

            modelBuilder.Entity<ResumeRole>(e =>
            {
                e.ToTable("Roles", "Membership");
            });

            modelBuilder.Entity<ResumeRoleClaim>(e =>
            {
                e.ToTable("RoleClaims", "Membership");
            });

            modelBuilder.Entity<ResumeUserClaim>(e =>
            {
                e.ToTable("UserClaims", "Membership");
            });

            modelBuilder.Entity<ResumeUserLogin>(e =>
            {
                e.ToTable("UserLogins", "Membership");
            });

            modelBuilder.Entity<ResumeUserToken>(e =>
            {
                e.ToTable("UserTokens", "Membership");
            });
        }
    }
}
