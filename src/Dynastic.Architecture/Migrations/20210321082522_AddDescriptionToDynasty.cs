using Microsoft.EntityFrameworkCore.Migrations;

namespace Dynastic.Architecture.Migrations.Dynastic
{
    public partial class AddDescriptionToDynasty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dynasties",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dynasties");
        }
    }
}
