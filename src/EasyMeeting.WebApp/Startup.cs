using EasyMeeting.BLL.Repository;
using EasyMeeting.BLL.Services;
using EasyMeeting.Common.Interfaces;
using EasyMeeting.DAL;
using EasyMeeting.DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyMeeting.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EasyMeetingDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnections")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<EasyMeetingDbContext>().AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            var options = new RewriteOptions().AddRedirect("(.*)/$", "https://www.youtube.com/watch?v=dPWkNS5AMVM&t=578s").AddRedirect("admin.php", "https://www.youtube.com/watch?v=dPWkNS5AMVM&t=578s");
            app.UseRewriter(options);

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("admin.php", async context =>
                {
                    await context.Response.CompleteAsync();
                });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
