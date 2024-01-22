using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvccore.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

//services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("GoreLiveDBConnection")));
services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("GoBibleLiveDBConnection")));


services.AddControllersWithViews();
services.AddMvc(option => option.EnableEndpointRouting = false).AddXmlSerializerFormatters();
//services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
services.AddScoped<IAudioLecturesRepository, SQLAudioLecturesRepository>();
//services.AddScoped<IHeading1Repository, MockHeading1Repository>();
//services.AddScoped<IHeading1Repository, SQLHeading1Repository>();
services.AddScoped<ICommandmentsRepository, SQLCommandmentsRepository>();

services.AddAuthentication();
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



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} 
else 
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthentication();

//app.UseHttpsRedirection();
//app.UseMvcWithDefaultRoute();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
