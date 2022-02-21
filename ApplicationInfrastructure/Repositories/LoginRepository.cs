using ApplicationCore.DTOs;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationInfrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInfrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DBcontext storeContext;
        private readonly IMapper mapper;

        public LoginRepository(DBcontext storeContext, IMapper mapper)
        {
            this.storeContext = storeContext;
            this.mapper = mapper;
        }
        public async Task<UserResponse> ValidateLoginDetails(string username)
        {
            var response = await storeContext.UR.FromSql("Exec getUserDetailOnRoleBasis @Username",new SqlParameter("@Username", username)).FirstOrDefaultAsync();
            return response;
        }
        public async Task<UserAuthRole> IsAuthenticated(string Username, string password)
        {
            var response = await storeContext.UAR.FromSql("Exec isauthenticate @Username,@password", new SqlParameter("@Username", Username), new SqlParameter("@password", password)).FirstOrDefaultAsync();
            return response;
        }
        public async Task<ClientResponse> ValidateclientResponses(string username)
        {
            var response = await storeContext.CR.FromSql("Exec getUserDetailOnRoleBasis @Username", new SqlParameter("@Username", username)).FirstOrDefaultAsync();
            return response;
        }
        public async Task<int> UpdateAgentDetails(UpdateUserDetailsDTO userDetails)
        {
            try
            {
                if (storeContext != null)
                {
                    if (userDetails.RoleType == "Agent")
                    {
                        var entity = storeContext.Agent_Detail.Where(a => a.AgentId == userDetails.UserId).FirstOrDefault();
                        if (entity != null)
                        {
                            entity.AgentId = userDetails.UserId;
                            entity.FirstName = userDetails.FirstName;
                            entity.LastName = userDetails.LastName;
                            entity.Email = userDetails.Email;
                            entity.Address = userDetails.Address;
                            entity.PhoneNo = userDetails.PhoneNo;

                            await storeContext.SaveChangesAsync();

                            return 1;
                        }
                        else if (userDetails.RoleType == "Admin")
                        {
                            var entitynew = storeContext.Admin_Detail.Where(a => a.AdminId == userDetails.UserId).FirstOrDefault();

                            if (entitynew != null)
                            {
                                entitynew.PhoneNo = userDetails.PhoneNo;
                                entitynew.Email = userDetails.Email;
                                entitynew.FirstName = userDetails.FirstName;
                                entitynew.LastName = userDetails.LastName;
                                entitynew.Address = userDetails.Address;
                                entitynew.AdminId = userDetails.UserId;

                                await storeContext.SaveChangesAsync();
                                return 1;

                            }
                        }
                        return 0;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                { 
                    return 0; 
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
