using ApplicationCore.DTOs;
using ApplicationCore.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IAgentRepository
    {
        Task<List<AgentResponse>> GetAgentDetails();
        Task <int>InsertAgentDetails(InsertAgentDetailsDTO agentInfo);
    }
}
