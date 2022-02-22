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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLogin>().HasIndex(p => new { p.userName}).IsUnique();
            modelBuilder.Entity<UserLogin>().HasIndex(p => new { p.UserId }).IsUnique();
            modelBuilder.Entity<AdminDetail>().HasIndex(p => new { p.Email }).IsUnique();
            modelBuilder.Entity<AdminDetail>().HasIndex(p => new { p.PhoneNo }).IsUnique();
            modelBuilder.Entity<AgentDetail>().HasIndex(p => new { p.Email}).IsUnique();
            modelBuilder.Entity<AgentDetail>().HasIndex(p => new { p.PhoneNo }).IsUnique();
            modelBuilder.Entity<ClientDetail>().HasIndex(p => new { p.Email }).IsUnique();
            modelBuilder.Entity<ClientDetail>().HasIndex(p => new { p.PhoneNo }).IsUnique();
            modelBuilder.Entity<ClientAccountDetail>().HasIndex(p => new {p.ClientId }).IsUnique();

           // modelBuilder.Entity<ClientDetail>().Property(a => a.ClientId).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();

            modelBuilder.Query<UserResponse>();
            modelBuilder.Query<ClientResponse>();
            modelBuilder.Query<UserAuthRole>();
            modelBuilder.Query<AgentResponse>();
            modelBuilder.Query<ClientAccountDetails>();
            //modelBuilder.Ignore<UserResponse>();
            //modelBuilder.Ignore<ClientResponse>();
            //modelBuilder.Ignore<UserAuthRole>();
            //modelBuilder.Ignore<AgentResponse>();
            //modelBuilder.Ignore<ClientAccountDetails>();
        }
        public DbSet<UserLogin> UserLogin_Detail { get; set; }
        public DbSet<RoleMaster> Role_Detail { get; set; }
        public DbSet<AgentDetail> Agent_Detail { get; set; }
        public DbSet<AdminDetail> Admin_Detail { get; set; }
        public DbSet<ClientDetail> Client_Detail { get; set; }
        public DbSet<ClientAccountDetail> ClientAccount_Detail { get; set; }
        public virtual DbQuery<UserResponse> UR { get; set; }
        public virtual DbQuery<ClientResponse> CR { get; set; }
        public virtual DbQuery<UserAuthRole> UAR { get; set; }
        public virtual DbQuery<AgentResponse> AR { get; set; }
        public virtual DbQuery<ClientAccountDetails> CAD { get; set; }
        
    }
}
