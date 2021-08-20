using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoApplication.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartyIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyIdentities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PartyIdentityId = table.Column<int>(type: "int", nullable: false),
                    PartyIdentityId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartyContacts_PartyIdentities",
                        column: x => x.PartyIdentityId,
                        principalTable: "PartyIdentities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartyContacts_PartyIdentities_PartyIdentityId1",
                        column: x => x.PartyIdentityId1,
                        principalTable: "PartyIdentities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PartyContacts_PartyIdentityId",
                table: "PartyContacts",
                column: "PartyIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyContacts_PartyIdentityId1",
                table: "PartyContacts",
                column: "PartyIdentityId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartyContacts");

            migrationBuilder.DropTable(
                name: "PartyIdentities");
        }
    }
}
