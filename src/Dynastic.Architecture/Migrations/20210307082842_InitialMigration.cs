using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dynastic.Architecture.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: true),
                    Middlename = table.Column<string>(type: "text", nullable: true),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    MotherId = table.Column<Guid>(type: "uuid", nullable: true),
                    FatherId = table.Column<Guid>(type: "uuid", nullable: true),
                    DynastyId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_People_FatherId",
                        column: x => x.FatherId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_People_MotherId",
                        column: x => x.MotherId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => new { x.PersonId, x.PartnerId });
                    table.ForeignKey(
                        name: "FK_Relationships_People_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relationships_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dynasties_HeadId",
                table: "Dynasties",
                column: "HeadId");

            migrationBuilder.CreateIndex(
                name: "IX_People_DynastyId",
                table: "People",
                column: "DynastyId");

            migrationBuilder.CreateIndex(
                name: "IX_People_FatherId",
                table: "People",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_People_MotherId",
                table: "People",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_PartnerId",
                table: "Relationships",
                column: "PartnerId");

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
                name: "FK_Dynasties_People_HeadId",
                table: "Dynasties");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Dynasties");
        }
    }
}
