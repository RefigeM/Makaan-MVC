using Makaan2.Contexts;
using Makaan2.Models;
using Makaan2.ViewModels.DepartmentVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Makaan2.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]

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
			if(id == null) return BadRequest();
			var data = await _context.Departments.FindAsync(id);
			if (data == null) return NotFound();
			_context.Departments.Remove(data);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}
		public async Task<IActionResult> Info(int? id)
		{
			var data = await _context.Departments.FindAsync(id);
			if (data == null) NotFound();
			return View(data);
		}
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(DepartmentCreateVM vm)
		{
			if (vm == null) throw new Exception("Can't be null");
			if (!ModelState.IsValid) return View(vm);
			Department department = new Department
			{
				Name = vm.Name
			};
			await _context.Departments.AddAsync(department);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Update(int? id)
		{
			if (id == null) return BadRequest();
			var data = await _context.Departments.FindAsync(id);
			if (data == null) return NotFound();
			DepartmentUpdateVM vm = new DepartmentUpdateVM
			{
			Name = data.Name
			};
			return	View(vm);	
		}
		[HttpPost]
		public async Task<IActionResult> Update(int? id, DepartmentUpdateVM vm) 
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}
		var data =await	_context.Departments.FindAsync(id);
			if (data is not null)
			{
				data.Name = vm.Name;

				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));	
		}


	}
}
