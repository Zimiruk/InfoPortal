using InfoPortal.DAL;
using InfoPortal.DI;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InfoPortal.WebMVC
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });

            services.AddRazorPages();
            services.IoCRegistry();
            services.AddTransient(_ => new SQLDataAccess(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
              });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            ///TODO Think over
            app.UseMvc(routes =>
            {
                routes.MapRoute("create", "/article/create", new { controller = "Article", action = "Create" });
                routes.MapRoute("detail", "/article/{id}", new { controller = "Article", action = "Detail" });
       

                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=Index}/{id?}");
            });
        }
    }
}
