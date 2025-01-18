using Makaan2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makaan2.Configuartions
{
	public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		void IEntityTypeConfiguration<Department>.Configure(EntityTypeBuilder<Department> builder)
		{
			builder.Property(d => d.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.HasMany(d => d.Agents)
				.WithOne(a => a.Department)
				.HasForeignKey(a => a.DepartmentId);
		}
	}
}
