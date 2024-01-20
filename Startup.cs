using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvccore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel;

namespace mvccore
{
    public class Startup
    {

        private IConfiguration? _config;
        public Startup(IConfiguration configuration)
        {
                        //Configuration = configuration;            
            
                _config = configuration;      


            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("GoreLiveDBConnection")));
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("GoBibleLiveDBConnection")));


            services.AddControllersWithViews();
            services.AddMvc(option => option.EnableEndpointRouting = false).AddXmlSerializerFormatters();
            //services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddScoped<IAudioLecturesRepository, SQLAudioLecturesRepository>();
            //services.AddScoped<IHeading1Repository, MockHeading1Repository>();
            //services.AddScoped<IHeading1Repository, SQLHeading1Repository>();
            services.AddScoped<ICommandmentsRepository, SQLCommandmentsRepository>();


            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


            services.ConfigureApplicationCookie(options => 
                    options.AccessDeniedPath = new PathString("/Administration/AccessDenied"));


            services.AddAuthorization(options => 
            {
                options.AddPolicy("DeleteRolePolicy", 
                    policy => policy.RequireClaim("Delete Role")
                                    .RequireClaim("Create Role"));

                options.AddPolicy("EditRolePolicy",
                            policy => policy.RequireClaim("Edit Role", "true"));

                options.AddPolicy("AdminRolePolicy",
                            policy => policy.RequireRole("Admin"));

            });

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
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            //app.UseMvcWithDefaultRoute();

            app.UseRouting();
            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
