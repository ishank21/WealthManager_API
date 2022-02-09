using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entitites;
using ApplicationCore.DTOs;
using Microsoft.EntityFrameworkCore;


namespace ApplicationInfrastructure.Context
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options) : base(options)
        {

        }
        public DbSet<UserLogin> UserLogin_Detail { get; set; }
        public DbSet<RoleMaster> Role_Detail { get; set; }
        public DbSet<AgentDetail> Agent_Detail { get; set; }
        public DbSet<AdminDetail> Admin_Detail { get; set; }
        public DbSet<ClientDetail> Client_Detail { get; set; }
        public DbSet<ClientAccountDetail> ClientAccount_Detail { get; set; }
        public virtual DbSet<UserResponse> UR { get; set; }
        public virtual DbSet<ClientResponse> CR { get; set; }
        public virtual DbSet<UserAuthRole> UAR { get; set; }
        public virtual DbSet<AgentResponse> AR { get; set; }
        public virtual DbSet<ClientAccountDetails> CAD { get; set; }
        
    }
}
