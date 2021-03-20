using Microsoft.EntityFrameworkCore.Migrations;

namespace Dynastic.Architecture.Migrations.Dynastic
{
    public partial class AddUserDynastyKeyToDynasty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDynasties",
                table: "UserDynasties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDynasties",
                table: "UserDynasties",
                columns: new[] { "Id", "DynastyId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDynasties",
                table: "UserDynasties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDynasties",
                table: "UserDynasties",
                column: "Id");
        }
    }
}
