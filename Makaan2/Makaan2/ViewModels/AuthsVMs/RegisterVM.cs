using System.ComponentModel.DataAnnotations;

namespace Makaan2.ViewModels.AuthsVMs
{
	public class RegisterVM
	{
		[Required, MaxLength(64, ErrorMessage ="Fullname 64-den cox ola bilmez")]
		public string Fullname { get; set; }
		[Required, MaxLength(128, ErrorMessage = "Email 128-den cox ola bilmez"), DataType(DataType.EmailAddress)]

		public string Email { get; set; }
		[Required, MaxLength(128, ErrorMessage = "username 128-den cox ola bilmez")]

		public string Username { get; set; }
		[Required, MaxLength(64, ErrorMessage = "Password 64-den cox ola bilmez"), DataType(DataType.Password)]

		public string Password { get; set; }
		[Required, MaxLength(64, ErrorMessage = "Password 64-den cox ola bilmez"), DataType(DataType.Password), Compare(nameof(Password))]

		public string RePassword { get; set; }
	}
}
