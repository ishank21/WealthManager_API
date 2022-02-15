using ApplicationCore.Common;
using ApplicationCore.DTOs;
using ApplicationCore.Entitites;
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
        public async Task<int> InsertClientDetails(InsertClientDetailsDTO agentInfo)
        {
            if (storeContext != null)
            {
                if (storeContext.UserLogin_Detail.Where(X => X.UserId == agentInfo.AgentId).FirstOrDefault() != null)
                {
                    ClientDetail clientDetails = new ClientDetail();
                    clientDetails.FirstName = agentInfo.FirstName;
                    clientDetails.LastName = agentInfo.LastName;
                    clientDetails.Email = agentInfo.Email;
                    clientDetails.Address = agentInfo.Address;
                    clientDetails.PhoneNo = agentInfo.PhoneNo;
                    clientDetails.AgentId = agentInfo.AgentId;
                    clientDetails.ClientId = "CL" + CommonMethods.GenerateRandomNo().ToString();
                    clientDetails.ClientType = (ClientType)agentInfo.ClientType;
                    storeContext.Client_Detail.Add(clientDetails);

                    await storeContext.SaveChangesAsync();
                    return 1;
                }
                else
                    return 0;
            }
            else
                return 0;
        }
        public async Task<int> InsertClientAccountDetails(InsertClientAccountDetails Clientdetails)
        {
            if (storeContext != null)
            {
                if (storeContext.Client_Detail.Where(x => x.ClientId == Clientdetails.ClientId).FirstOrDefault() != null)
                {
                    ClientAccountDetail clientAccountDetails = new ClientAccountDetail();
                    clientAccountDetails.AccountId = Clientdetails.AccountId;
                    clientAccountDetails.ProgramName = Clientdetails.ProgramName;
                    clientAccountDetails.CustodianAccountNumber = Clientdetails.CustodianAccountNumber;
                    clientAccountDetails.MarketValue = Clientdetails.MarketValue;
                    clientAccountDetails.CustodianName = Clientdetails.CustodianName;
                    clientAccountDetails.ProgramId = Clientdetails.ProgramId;
                    clientAccountDetails.IsClosed = Clientdetails.IsClosed;
                    clientAccountDetails.CustodianId = Clientdetails.CustodainId;
                    clientAccountDetails.RegisteredName = Clientdetails.RegisteredName;
                    clientAccountDetails.ClientId = Clientdetails.ClientId;
                    storeContext.ClientAccount_Detail.Add(clientAccountDetails);

                    await storeContext.SaveChangesAsync();
                    return 1;
                }
                else
                    return 0;
            }
            else
                return 0;
        }
    }

}