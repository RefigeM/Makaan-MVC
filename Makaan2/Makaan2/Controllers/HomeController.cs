using Makaan2.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Makaan2.Controllers
{
	public class HomeController : Controller
	{
		private readonly MakaanDbContext _context;

		public HomeController(MakaanDbContext context)
		{
			_context = context;	
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Agents.Include(x => x.Department).ToListAsync());
		}
	}
}
