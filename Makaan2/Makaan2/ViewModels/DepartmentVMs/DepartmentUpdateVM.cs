using System.ComponentModel.DataAnnotations;

namespace Makaan2.ViewModels.DepartmentVMs
{
	public class DepartmentUpdateVM
	{
		[MaxLength(32,ErrorMessage ="32'den cox ola bilmez")]
		[Required]
		public string Name { get; set; }
	}
}
