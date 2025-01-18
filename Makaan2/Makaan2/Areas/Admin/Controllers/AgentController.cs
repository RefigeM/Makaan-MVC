using Makaan2.Contexts;
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
            return View(await _context.Agents.Include(x =>x.Department).ToListAsync());
        }
        public async Task<IActionResult> Delete(int id)
        {
         var data=  await _context.Agents.FindAsync(id);
            if (data == null) throw new Exception("Not found");
            _context.Agents.Remove(data);
          await  _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]

        public async Task<IActionResult> Info(int id) 
        {
            if (id == null) return BadRequest();
       var data = await  _context.Agents.FindAsync(id);
            if (data == null) throw new Exception("Not found");
			return View(data);
		}

	}
}
