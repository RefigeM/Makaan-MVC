using Makaan2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Makaan2.Contexts
{
	public class MakaanDbContext : IdentityDbContext
	{
		public MakaanDbContext(DbContextOptions opt) : base(opt)
		{
		}
		public DbSet<Agent> Agents { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<AppUser> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MakaanDbContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}

	}
}
