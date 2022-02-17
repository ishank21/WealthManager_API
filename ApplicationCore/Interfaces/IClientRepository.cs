using ApplicationCore.DTOs;
using ApplicationCore.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientResponse>> GetClientDetailsForAgent(string agentId);
        Task<List<ClientAccountDetails>> GetAccountDetailsByClientId(string clientId);
        Task<int> InsertClientDetails(InsertClientDetailsDTO agentInfo);
        Task<int> UpdateClientDetails(UpdateClientDetailsDTO ClientUpdate);
        Task<int> InsertClientAccountDetails(InsertClientAccountDetails Clientdetails);
    }
}
