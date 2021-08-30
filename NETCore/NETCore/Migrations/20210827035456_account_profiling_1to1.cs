using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore.Migrations
{
    public partial class account_profiling_1to1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Profiling_NIK",
                table: "Accounts");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiling_Accounts_NIK",
                table: "Profiling",
                column: "NIK",
                principalTable: "Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiling_Accounts_NIK",
                table: "Profiling");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Profiling_NIK",
                table: "Accounts",
                column: "NIK",
                principalTable: "Profiling",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
