using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore.Migrations
{
    public partial class profiling_education_1toMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiling_Accounts_NIK",
                table: "Profiling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiling",
                table: "Profiling");

            migrationBuilder.RenameTable(
                name: "Profiling",
                newName: "Profilings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profilings",
                table: "Profilings",
                column: "NIK");

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    University_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profilings_Education_Id",
                table: "Profilings",
                column: "Education_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Accounts_NIK",
                table: "Profilings",
                column: "NIK",
                principalTable: "Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Educations_Education_Id",
                table: "Profilings",
                column: "Education_Id",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Accounts_NIK",
                table: "Profilings");

            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Educations_Education_Id",
                table: "Profilings");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profilings",
                table: "Profilings");

            migrationBuilder.DropIndex(
                name: "IX_Profilings_Education_Id",
                table: "Profilings");

            migrationBuilder.RenameTable(
                name: "Profilings",
                newName: "Profiling");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiling",
                table: "Profiling",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiling_Accounts_NIK",
                table: "Profiling",
                column: "NIK",
                principalTable: "Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
