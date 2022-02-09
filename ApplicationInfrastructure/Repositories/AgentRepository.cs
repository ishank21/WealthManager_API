using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationInfrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInfrastructure.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly DBcontext storeContext;
        private readonly IMapper mapper;

        public AgentRepository(DBcontext storeContext, IMapper mapper)
        {
            this.storeContext = storeContext;
            this.mapper = mapper;
        }
        public async Task<List<AgentResponse>> GetAgentDetails()
        {
            var response = await storeContext.AR.FromSqlRaw("Select * from getAgents").AsNoTracking().ToListAsync();
            return response;

        }
    }
}
