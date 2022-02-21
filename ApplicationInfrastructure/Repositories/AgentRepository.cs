using ApplicationCore.Common;
using ApplicationCore.DTOs;
using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using ApplicationInfrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
            try
            {
                var response = await storeContext.AR.FromSql("Select * from getAgents").AsNoTracking().ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<int> InsertAgentDetails(InsertAgentDetailsDTO agentDetails)
        {
            try
            {
                if (storeContext != null)
                {
                    UserLogin newLogin = new UserLogin();
                    newLogin.userName = agentDetails.UserName;
                    newLogin.Password = agentDetails.Password;
                    newLogin.guidId = Guid.NewGuid().ToString();
                    newLogin.RoleId = CommonMethods.GetRoleType(agentDetails.RoleType);
                    newLogin.hasActiveRole = agentDetails.HasActiveRole;
                    newLogin.UserId = "AG" + CommonMethods.GenerateRandomNo().ToString();
                    storeContext.UserLogin_Detail.Add(newLogin);

                    AgentDetail agentDetail = new AgentDetail();
                    agentDetail.FirstName = agentDetails.FirstName;
                    agentDetail.LastName = agentDetails.LastName;
                    agentDetail.Email = agentDetails.Email;
                    agentDetail.Address = agentDetails.Address;
                    agentDetail.PhoneNo = agentDetails.PhoneNo;
                    agentDetail.AgentId = newLogin.UserId;
                    storeContext.Agent_Detail.Add(agentDetail);

                    await storeContext.SaveChangesAsync();
                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception)
            {
                return -1;
            }

        }
       
    }
}
