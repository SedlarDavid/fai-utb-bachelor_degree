using a5pwt_ctvrtek.Infrastructure.Data;
using a5pwt_ctvrtek.Infrastructure.Identity.Roles;
using a5pwt_ctvrtek.Infrastructure.Identity.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;

namespace a5pwt_ctvrtek.Infrastructure.Configuration
{
    public class InfrastructureServiceConfiguration
    {
        public static void Load(IServiceCollection services, IHostingEnvironment environment)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer("Server=databaze.fai.utb.cz;Database=A17147_A5PWT_Projekt;User ID=A17147;Password=Stevejobs1;persist security info=True;multipleactiveresultsets=True;");
                //options.UseInMemoryDatabase("UTB.Shop");
            });

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Admin/Security/Login";
                options.LogoutPath = "/Admin/Security/Logout";
                options.SlidingExpiration = true;
            });
        }
    }
}
