using Microsoft.AspNetCore.Identity;

namespace Makaan2.Models
{
	public class AppUser : IdentityUser
	{
		public string Fullname { get; set; }
		public string? ProfilImage { get; set; }
		public string? Address { get; set; }
	}
}
