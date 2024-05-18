using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Utilities.IoC;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Estate.UI.Areas.Admin.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddDbContext<EStateContext>(
	conf => conf.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EStateDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False").UseLazyLoadingProxies());

builder.Services.AddIdentity<UserAdmin, IdentityRole>().AddEntityFrameworkStores<EStateContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(opt =>
{
	opt.SignIn.RequireConfirmedPhoneNumber = false;
	opt.SignIn.RequireConfirmedEmail = false;
	opt.SignIn.RequireConfirmedAccount = false;

	opt.Password.RequireDigit = false;
	opt.Password.RequiredLength = 8;
	opt.Password.RequireLowercase = false;
	opt.Password.RequireUppercase = false;
	opt.Password.RequireNonAlphanumeric = false;
	opt.User.AllowedUserNameCharacters = "abcçdefgðhiýjklmnoöprsþtuüvyzABCÇDEFGÐHÝIJKLMNOÖPRSÞTUÜVYZ0123456789-._";
});

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Admin/Admin/Login";
	options.LogoutPath = "/Admin/Admin/LogOut";
	options.AccessDeniedPath = "/Admin/Admin/AccessDeniedPath";
	options.ExpireTimeSpan = TimeSpan.FromMinutes(6);
});
builder.Services.AddSession();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
	.ConfigureContainer<ContainerBuilder>(builder =>
	{
		builder.RegisterModule(new AutofacBusinessModule());
	});

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
	new CoreModule()
});



var app = builder.Build();

app.PrepareDatabase().GetAwaiter().GetResult();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
	);
});

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
