using Makaan2.Models.Common;

namespace Makaan2.Models
{
	public class Agent :BaseEntity
	{
		public string Name { get; set; }
		public string Image { get; set; }
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
	}
}
