using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dynastic.Architecture.Migrations
{
    public partial class RelationshipsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dynasties_People_HeadId",
                table: "Dynasties");

            migrationBuilder.DropIndex(
                name: "IX_Dynasties_HeadId",
                table: "Dynasties");

            migrationBuilder.DropColumn(
                name: "HeadId",
                table: "Dynasties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HeadId",
                table: "Dynasties",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dynasties_HeadId",
                table: "Dynasties",
                column: "HeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dynasties_People_HeadId",
                table: "Dynasties",
                column: "HeadId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
