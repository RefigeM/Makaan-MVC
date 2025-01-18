using Makaan2.Models;

namespace Makaan2.ViewModels.Agent
{
	public class AgentListItemVM
	{
		public string Fullname { get; set; }
		public string Image { get; set; }
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
	}
}
