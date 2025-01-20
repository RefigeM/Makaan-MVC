using System.ComponentModel.DataAnnotations;

namespace Makaan2.ViewModels.DepartmentVMs
{
	public class DepartmentCreateVM
	{
		[Required, MaxLength(32,ErrorMessage ="Name 32'den boyuk ola bilmez.")]
		public string Name { get; set; }
	}
}
