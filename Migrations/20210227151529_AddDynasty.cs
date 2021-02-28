using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dynastic.Migrations
{
    public partial class AddDynasty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DynastyId",
                table: "People",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dynasties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    HeadId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dynasties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dynasties_People_HeadId",
                        column: x => x.HeadId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_DynastyId",
                table: "People",
                column: "DynastyId");

            migrationBuilder.CreateIndex(
                name: "IX_Dynasties_HeadId",
                table: "Dynasties",
                column: "HeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Dynasties_DynastyId",
                table: "People",
                column: "DynastyId",
                principalTable: "Dynasties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Dynasties_DynastyId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Dynasties");

            migrationBuilder.DropIndex(
                name: "IX_People_DynastyId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DynastyId",
                table: "People");
        }
    }
}
