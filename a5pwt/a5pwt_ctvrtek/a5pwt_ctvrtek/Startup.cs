using System;
using System.Threading.Tasks;
using a5pwt_ctvrtek.Application.Configuration;
using a5pwt_ctvrtek.Domain.Constants;
using a5pwt_ctvrtek.Infrastructure.Identity.Roles;
using a5pwt_ctvrtek.Infrastructure.Identity.Users;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace a5pwt_ctvrtek
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IHostingEnvironment Environment { get; set; }
        public IContainer Container { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();
            ServiceConfiguration.Load(services, Environment);
            return ConfigureAutofacContainer(services);
        }

        private IServiceProvider ConfigureAutofacContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationDependencyModule>();
            builder.Populate(services);

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Products}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Products}/{action=Index}/{id?}");
            });

            EnsureRolesCreated(app).ConfigureAwait(false);
        }

        private async Task EnsureRolesCreated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<Role>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                string[] roles = { Roles.User, Roles.Admin, Roles.Manager };

                foreach (var role in roles)
                {
                    var roleExists = await roleManager.RoleExistsAsync(role);
                    if (!roleExists)
                        await roleManager.CreateAsync(new Role(role));
                }

                var admin = new User
                {
                    UserName = "admin@utb.cz",
                    Email = "admin@utb.cz",
                    EmailConfirmed = true
                };
                var password = "Heslo_123";

                var user = await userManager.FindByEmailAsync(admin.Email);
                if (user == null)
                {
                    var createdUser = await userManager.CreateAsync(admin, password);
                    if (createdUser.Succeeded)
                    {
                        foreach (var role in roles)
                        {
                            await userManager.AddToRoleAsync(admin, role);
                        }
                    }
                }
            }
        }
    }

}
