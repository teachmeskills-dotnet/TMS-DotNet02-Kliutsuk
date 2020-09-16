using AutoMapper;
using EasyMeeting.BLL.Automapper;
using EasyMeeting.BLL.Repository;
using EasyMeeting.BLL.Services;
using EasyMeeting.Common.Interfaces;
using EasyMeeting.DAL;
using EasyMeeting.DAL.Models;
using EasyMeeting.WebApp.Automapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace EasyMeeting.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EasyMeetingDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnections")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<EasyMeetingDbContext>().AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<MeetingService>();
            services.AddScoped<ParticipiantService>();
            services.AddAutoMapper(c => { c.AddProfile<MeetingMap>(); c.AddProfile<ParticipiantsMap>(); c.AddProfile<AutoMapping>(); }, typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            var options = new RewriteOptions()
                .AddRedirect("(.*)/$", "https://www.youtube.com/watch?v=dPWkNS5AMVM&t=578s")
                .AddRedirect("admin.php", "https://www.youtube.com/watch?v=dPWkNS5AMVM&t=578s");
            app.UseRewriter(options);

            app.UseSerilogRequestLogging();

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
