using Makaan2.Models;
using System.ComponentModel.DataAnnotations;

namespace Makaan2.ViewModels.Agent
{
	public class AgentCreateVM
	{
		[Required,MaxLength(32, ErrorMessage ="32den boyuk ola bilmez")]
		public string Fullname { get; set; }
		[Required, MaxLength(32, ErrorMessage = "32den boyuk ola bilmez")]

		public string Image { get; set; }
		//public IFormFile Image { get; set; }
		[Required]
		public int DepartmentId { get; set; }

		public IEnumerable<Department> Departments { get; set; }



	}
}
