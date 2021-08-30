using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore.Migrations
{
    public partial class account_Person_1to1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_Accounts_Persons_NIK",
                        column: x => x.NIK,
                        principalTable: "Persons",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
