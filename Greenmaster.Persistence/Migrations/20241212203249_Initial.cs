using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Period = table.Column<int[]>(type: "integer[]", maxLength: 100, nullable: false),
                    IsFragrant = table.Column<bool>(type: "boolean", nullable: false),
                    IsEdible = table.Column<bool>(type: "boolean", nullable: false),
                    AttractsPollinators = table.Column<bool>(type: "boolean", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Genus = table.Column<string>(type: "text", nullable: false),
                    Species = table.Column<string>(type: "text", nullable: false),
                    CommonName = table.Column<string>(type: "text", nullable: false),
                    Cultivar = table.Column<string>(type: "text", nullable: true),
                    BloomId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SymbioticRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SymbiontAId = table.Column<Guid>(type: "uuid", nullable: false),
                    SymbiontBId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymbioticRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SymbioticRelations_Plants_SymbiontAId",
                        column: x => x.SymbiontAId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SymbioticRelations_Plants_SymbiontBId",
                        column: x => x.SymbiontBId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SymbioticRelations_SymbiontAId",
                table: "SymbioticRelations",
                column: "SymbiontAId");

            migrationBuilder.CreateIndex(
                name: "IX_SymbioticRelations_SymbiontBId",
                table: "SymbioticRelations",
                column: "SymbiontBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blooms");

            migrationBuilder.DropTable(
                name: "SymbioticRelations");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
