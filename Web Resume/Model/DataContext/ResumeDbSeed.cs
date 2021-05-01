using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Resume.Model.Entity.Membership;

namespace Web_Resume.Model.DataContext
{
    public static class ResumeDbSeed
    {
        static internal IApplicationBuilder Seed(this IApplicationBuilder builder)
        {
            return builder;
        }

        static internal IApplicationBuilder SeedIdentity(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ResumeUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ResumeRole>>();

                ResumeRole superAdminRole = roleManager.FindByNameAsync("Admin").Result;

                if (superAdminRole == null)
                {
                    superAdminRole = new ResumeRole
                    {
                        Name = "Admin"
                    };
                    roleManager.CreateAsync(superAdminRole).Wait();
                }

                ResumeUser superAdminUser = userManager.FindByEmailAsync("abbas@code.edu.az").Result;

                if (superAdminUser == null)
                {
                    superAdminUser = new ResumeUser
                    {
                        Email = "abbas@code.edu.az",
                        UserName = "abbas",
                        EmailConfirmed = true
                    };

                    var resultUser = userManager.CreateAsync(superAdminUser, "123").Result;

                    if (resultUser.Succeeded)
                    {
                        var roleResult = userManager.AddToRoleAsync(superAdminUser, "Admin").Result;
                    }


                }
                else if (!userManager.IsInRoleAsync(superAdminUser, "Admin").Result)
                {
                    userManager.AddToRoleAsync(superAdminUser, "Admin").Wait();
                }

            }


            return builder;
        }
    }
}
