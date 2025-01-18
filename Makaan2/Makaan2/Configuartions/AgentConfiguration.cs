using Makaan2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makaan2.Configuartions
{
	public class AgentConfiguration : IEntityTypeConfiguration<Agent>
	{
		void IEntityTypeConfiguration<Agent>.Configure(EntityTypeBuilder<Agent> builder)
		{
			builder.Property(a => a.Name)
				.IsRequired()
				.HasMaxLength(64);

			builder.Property(a => a.Image)
				.IsRequired()
				.HasMaxLength(255);

			builder.HasOne(a => a.Department)
				.WithMany(d => d.Agents)
				.HasForeignKey(a => a.DepartmentId);
		}
	}
}
