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
            this.storeContext=storeContext;
            this.mapper=mapper;
        }
        public async Task<List<UserResponse>> ValidateLoginDetails(string username, string password)=>
            await storeContext.UR.FromSqlInterpolated($"Exec getUserDetailOnRoleBasis'{username}','{password}'").ToListAsync();


    }
}
