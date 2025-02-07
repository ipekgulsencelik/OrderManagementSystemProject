using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess.Context;
using OrderManagement.Entity.Entitles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddDbContext<OrderManagementContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<OrderManagementContext>();

builder.Services.AddControllersWithViews(cfg =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    cfg.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = new PathString("/Login/SignIn");
    x.AccessDeniedPath = new PathString("/ErrorPage/AccessDenied/");
    x.LogoutPath = new PathString("/Login/Logout");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();