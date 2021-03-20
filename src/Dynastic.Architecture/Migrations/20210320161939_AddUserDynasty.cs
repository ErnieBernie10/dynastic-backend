using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dynastic.Architecture.Migrations.Dynastic
{
    public partial class AddUserDynasty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDynasties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DynastyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDynasties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDynasties_Dynasties_DynastyId",
                        column: x => x.DynastyId,
                        principalTable: "Dynasties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDynasties_DynastyId",
                table: "UserDynasties",
                column: "DynastyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDynasties");
        }
    }
}
