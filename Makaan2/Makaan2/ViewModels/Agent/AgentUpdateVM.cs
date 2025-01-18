namespace Makaan2.ViewModels.Agent
{
	public class AgentUpdateVM
	{
		public string Fullname { get; set; }
		public string ImageUrl { get; set; }
		public IFormFile Image { get; set; }
		public int DepartmentId { get; set; }

	}
}
