using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web_Resume.AppCode.Repositories;
using Web_Resume.Model.DataContext;
using Web_Resume.Model.Entity.Membership;

namespace Web_Resume
{
    public class Startup
    {
        public static string[] principals = null;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            var types = Assembly.GetExecutingAssembly().GetTypes();

            if (principals == null)
            {
                principals = types
                     .Where(t => typeof(ControllerBase).IsAssignableFrom(t) && t.IsDefined(typeof(AuthorizeAttribute), true))
                     .SelectMany(t => t.GetCustomAttributes<AuthorizeAttribute>())
                     .Union(types
                     .Where(t => typeof(ControllerBase).IsAssignableFrom(t))
                     .SelectMany(type => type.GetMethods())
                     .Where(method => method.IsPublic
                     && !method.IsDefined(typeof(NonActionAttribute))
                     && method.IsDefined(typeof(AuthorizeAttribute)))
                     .SelectMany(t => t.GetCustomAttributes<AuthorizeAttribute>()))
                     .Where(a => !string.IsNullOrWhiteSpace(a.Policy))
                                           .SelectMany(a => a.Policy.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                                           .Distinct()
                                           .ToArray();
            }
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(cfg => {
                var policyBuilder = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                cfg.Filters.Add(new AuthorizeFilter(policyBuilder));
            });

            services.AddIdentity<ResumeUser, ResumeRole>()
                .AddEntityFrameworkStores<ResumeDbContext>();

            services.AddScoped<UserManager<ResumeUser>>()
                .AddScoped<RoleManager<ResumeRole>>()
                .AddScoped<SignInManager<ResumeUser>>();

            services.AddScoped<PersonRepository>();
            services.AddDbContext<ResumeDbContext>(cfg=> {
                cfg.UseSqlServer(Configuration.GetConnectionString("cString"));
            });

            services.Configure<IdentityOptions>(cfg => {
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredLength = 3;
                cfg.Password.RequiredUniqueChars = 1;

                cfg.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.Cookie.SameSite = SameSiteMode.None;
                cfg.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                cfg.Cookie.HttpOnly = false;

                cfg.LoginPath = "/signin.html";
                cfg.AccessDeniedPath = "/accessdenied.html";
            });

            services.AddAuthentication();
            services.AddAuthorization(cfg =>
            {

                foreach (var principal in principals)
                {
                    cfg.AddPolicy(principal, p =>
                    {
                        //p.RequireClaim(principal, "1");
                        p.RequireAssertion(handler =>
                        {
                            return handler.User.IsInRole("Admin") || handler.User.HasClaim(principal, "1");
                        });
                    });
                }

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.SeedIdentity()
                .Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                   areaName: "admin",
                   name: "signinRoute",
                   pattern: "signin.html",
                   defaults: new
                   {
                       controller = "account",
                       action = "signin",
                       area = "admin"
                   });

                endpoints.MapAreaControllerRoute(
                  areaName: "admin",
                  name: "accessdeniedRoute",
                  pattern: "accessdenied.html",
                  defaults: new
                  {
                      controller = "account",
                      action = "accessdenied",
                      area = "admin"
                  });

                endpoints.MapAreaControllerRoute(
                    name: "defaultArea",
                    areaName: "admin",
                    pattern: "admin/{controller=dashboard}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
