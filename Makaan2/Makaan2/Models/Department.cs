using Makaan2.Models.Common;

namespace Makaan2.Models
{
	public class Department :BaseEntity
	{
		public string Name { get; set; }
		public ICollection<Agent> Agents { get; set; }
	}
}
