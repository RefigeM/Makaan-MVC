using Makaan2.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MakaanDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
});
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
		  );

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}"
	);

app.Run();
