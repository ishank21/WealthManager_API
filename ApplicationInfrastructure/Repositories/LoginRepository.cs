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
    }
}
