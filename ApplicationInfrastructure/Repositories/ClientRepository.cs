using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationInfrastructure.Context;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInfrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DBcontext storeContext;
        private readonly IMapper mapper;

        public ClientRepository(DBcontext storeContext, IMapper mapper)
        {
            this.storeContext = storeContext;
            this.mapper = mapper;
        }
        public async Task<List<ClientResponse>> GetClientDetailsForAgent(string agentId)
        {
            var response = await storeContext.CR.FromSqlRaw("Select * from getClientDetailsForAgent(@AgentId)", new SqlParameter("@AgentId", agentId)).AsNoTracking().ToListAsync();
            return response;
        }
        public async Task<List<ClientAccountDetails>> GetAccountDetailsByClientId(string clientId)
        {
            var response = await storeContext.CAD.FromSqlRaw("Select * from getAccountInformationForClient(@ClientId)", new SqlParameter("@ClientId", clientId)).AsNoTracking().ToListAsync();
            return response;

        }

    }
}
