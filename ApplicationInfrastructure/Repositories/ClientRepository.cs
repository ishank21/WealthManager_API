using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationInfrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var response = await storeContext.CR.FromSql("Select * from getClientDetailsForAgent(@AgentId)", new SqlParameter("@AgentId", agentId)).AsNoTracking().ToListAsync();
            return response;
        }
        public async Task<List<ClientAccountDetails>> GetAccountDetailsByClientId(string clientId)
        {
            var response = await storeContext.CAD.FromSql("Select * from getAccountInformationForClient(@ClientId)", new SqlParameter("@ClientId", clientId)).AsNoTracking().ToListAsync();
            return response;

        }

    }
}
