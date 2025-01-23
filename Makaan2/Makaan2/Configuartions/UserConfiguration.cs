using Makaan2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makaan2.Configuartions
{
	public class UserConfiguration : IEntityTypeConfiguration<AppUser>
	{
		public void Configure(EntityTypeBuilder<AppUser> builder)
		{
			builder.Property(u => u.Fullname)
				.IsRequired()
				.HasMaxLength(128);
			
		}
	}
}
