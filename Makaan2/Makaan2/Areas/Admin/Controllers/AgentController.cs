using Makaan2.Contexts;
using Makaan2.Models;
using Makaan2.ViewModels.Agent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Makaan2.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AgentController : Controller
	{
		private readonly MakaanDbContext _context;

		public AgentController(MakaanDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Agents.Include(x => x.Department).ToListAsync());
		}
		public async Task<IActionResult> Info(int? id)
		{
			if (id == null) return BadRequest();
			var data = await _context.Agents.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
			if (data == null) return NotFound();
			return View(data);
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null) return BadRequest();
			var data = await _context.Agents.FindAsync(id);
			if (data == null) return NotFound();
			_context.Agents.Remove(data);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}
		public async Task<IActionResult> Update(int? id)
		{
			if (id == null) return BadRequest();
			var data = await _context.Agents.FindAsync(id);
			if (data == null) return NotFound();
			AgentUpdateVM vm = new AgentUpdateVM
			{
				Fullname = data.Name,
				ImageUrl = data.Image,
				DepartmentId = data.DepartmentId,
			};
			return View(vm);

		}
		[HttpPost]
		public async Task<IActionResult> Update(int? id, AgentUpdateVM vm)
		{
			if (vm == null) throw new Exception("vm bos ola bilmez");
			var data = await _context.Agents.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
			if (data == null) return NotFound();
			data.Name = vm.Fullname;
			data.Image = vm.ImageUrl;
			data.DepartmentId = vm.DepartmentId;
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Create()
		{
			AgentCreateVM vm = new AgentCreateVM
			{
				Departments = await _context.Departments.Where(x => !x.IsDeleted).ToListAsync()
			};
			return View(vm);
		}
		[HttpPost]
		public async Task<IActionResult> Create(AgentCreateVM vm)
		{
			

			Agent agent = new Agent
			{
				Name = vm.Fullname,
				Image = vm.Image,
				DepartmentId = vm.DepartmentId,

			};
			await _context.AddAsync(agent);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}






	}
}
