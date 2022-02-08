using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationInfrastructure.Migrations
{
    public partial class newTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agent_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientType = table.Column<int>(type: "int", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientAccount_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustodianId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustodianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustodianAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAccount_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RoleType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Detail", x => x.Id);
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
        }
    }
}
