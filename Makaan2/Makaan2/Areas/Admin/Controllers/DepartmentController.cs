using Makaan2.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Makaan2.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DepartmentController : Controller
	{
		private readonly MakaanDbContext _context;

		public DepartmentController(MakaanDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Departments.ToListAsync());
		}
		public async Task<IActionResult> Delete(int? id)
		{
			var data = await _context.Departments.FindAsync(id);
			if (data == null) throw new Exception("Not found");
			_context.Departments.Remove(data);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}
		public async Task<IActionResult> Info(int? id)
		{
			var data = await _context.Departments.FindAsync(id);
			if (data == null) throw new Exception("Not Found");
			return View(data);
		}
	}
}
