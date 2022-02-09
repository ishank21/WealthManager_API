using ApplicationCore.DTOs;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationInfrastructure.Context;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
        public async Task<List<UserResponse>> ValidateLoginDetails(string username, string password)
        {
            var response = await storeContext.UR.FromSqlRaw("Exec getUserDetailOnRoleBasis @Username",new SqlParameter("@Username", username)).ToListAsync();
            return response;
        }
        public async Task<List<UserAuthRole>> IsAuthenticated(string Username, string password)
        {
            var response = await storeContext.UAR.FromSqlRaw("Exec isauthenticate @Username,@password", new SqlParameter("@Username", Username), new SqlParameter("@password", password)).AsNoTracking().ToListAsync();
            return response;
        }
        public async Task<List<ClientResponse>> ValidateclientResponses(string username, string password)
        {
            var response = await storeContext.CR.FromSqlRaw("Exec getUserDetailOnRoleBasis @Username", new SqlParameter("@Username", username)).ToListAsync();
            return response;
        }
    }
}
