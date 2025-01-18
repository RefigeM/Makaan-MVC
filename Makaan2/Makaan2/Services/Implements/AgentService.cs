using Makaan2.Contexts;
using Makaan2.Models;
using Makaan2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Makaan2.Services.Implements
{
	public class AgentService : IAgentService
	{
		private readonly MakaanDbContext _context;

		public AgentService(MakaanDbContext context)
		{
			_context = context;
		}

		public async Task CreateAgentAsync(Agent agent)
		{
			if (agent == null) throw new Exception("bos ola bilmez");
			await _context.Agents.AddAsync(agent);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAgentAsync(int id)
		{
			var agent = await _context.Agents.FindAsync(id);
			if (agent == null) throw new Exception("Not Found");
			_context.Remove(agent);
			await _context.SaveChangesAsync();
		}

		public async Task<Agent> GetAgentById(int id)
		{
			var agent = await _context.Agents.FindAsync(id);
			if (agent == null) throw new Exception("Not Found");
			return agent;
		}

		public async Task<List<Agent>> GetAllAgentsAsync()
		{
			return await _context.Agents.ToListAsync();
		}

		public Task UpdateAgentAsync(int id, Agent agent)
		{
			throw new NotImplementedException();
		}

		Task IAgentService.CreateAgentAsync(Agent agent)
		{
			throw new NotImplementedException();
		}

		Task IAgentService.DeleteAgent(int id)
		{
			throw new NotImplementedException();
		}

		Task<Agent> IAgentService.GetAgentById(int id)
		{
			throw new NotImplementedException();
		}

		Task<List<Agent>> IAgentService.GetAllAgentsAsync()
		{
			throw new NotImplementedException();
		}

		Task IAgentService.UpdateAgent(int id, Agent agent)
		{
			throw new NotImplementedException();
		}
	}
}
