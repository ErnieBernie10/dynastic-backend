using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dynastic.Migrations
{
    public partial class NullableParents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_People_FatherId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_People_MotherId",
                table: "People");

            migrationBuilder.AlterColumn<Guid>(
                name: "MotherId",
                table: "People",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "FatherId",
                table: "People",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_FatherId",
                table: "People",
                column: "FatherId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_MotherId",
                table: "People",
                column: "MotherId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_People_FatherId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_People_MotherId",
                table: "People");

            migrationBuilder.AlterColumn<Guid>(
                name: "MotherId",
                table: "People",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FatherId",
                table: "People",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_FatherId",
                table: "People",
                column: "FatherId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_MotherId",
                table: "People",
                column: "MotherId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
