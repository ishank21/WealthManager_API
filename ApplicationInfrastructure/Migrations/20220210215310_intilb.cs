using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationInfrastructure.Migrations
{
    public partial class intilb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    AdminId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agent_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    AgentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ClientType = table.Column<int>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: true),
                    AgentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientAccount_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<string>(nullable: true),
                    CustodianId = table.Column<string>(nullable: true),
                    CustodianName = table.Column<string>(nullable: true),
                    RegisteredName = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    CustodianAccountNumber = table.Column<string>(nullable: true),
                    MarketValue = table.Column<string>(nullable: true),
                    ProgramId = table.Column<string>(nullable: true),
                    ProgramName = table.Column<string>(nullable: true),
                    IsClosed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAccount_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    RoleType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    guidId = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    hasActiveRole = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin_Detail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin_Detail");

            migrationBuilder.DropTable(
                name: "Agent_Detail");

            migrationBuilder.DropTable(
                name: "Client_Detail");

            migrationBuilder.DropTable(
                name: "ClientAccount_Detail");

            migrationBuilder.DropTable(
                name: "Role_Detail");

            migrationBuilder.DropTable(
                name: "UserLogin_Detail");
        }
    }
}
