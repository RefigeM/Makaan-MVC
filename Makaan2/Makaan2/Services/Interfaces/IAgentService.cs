using Makaan2.Models;

namespace Makaan2.Services.Interfaces
{
	public interface IAgentService
	{
		Task<List<Agent>> GetAllAgentsAsync();
		Task<Agent> GetAgentById(int id);
		Task CreateAgentAsync(Agent agent);
		Task DeleteAgent(int id);	
		Task UpdateAgent(int id,Agent agent);
	}
}
