using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientEntities",
                columns: table => new
                {
                    ChatId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Company = table.Column<string>(type: "TEXT", nullable: true),
                    Position = table.Column<string>(type: "TEXT", nullable: true),
                    MemberBefore = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: true),
                    RigistrationDate = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientEntities", x => x.ChatId);
                });

            migrationBuilder.CreateTable(
                name: "ClientWithEventsEntities",
                columns: table => new
                {
                    EventId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientWithEventsEntities", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "EventEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventName = table.Column<string>(type: "TEXT", nullable: true),
                    RigistrationDate = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientEntities");

            migrationBuilder.DropTable(
                name: "ClientWithEventsEntities");

            migrationBuilder.DropTable(
                name: "EventEntities");
        }
    }
}
