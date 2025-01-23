using Makaan2.Contexts;
using Makaan2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MakaanDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
});
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
	opt.User.RequireUniqueEmail = true;
	opt.Password.RequiredLength = 3;
	opt.Password.RequireDigit = true;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<MakaanDbContext>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
		  );

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}"
	);

app.Run();
