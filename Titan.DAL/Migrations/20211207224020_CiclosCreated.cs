using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Titan.DAL.Migrations
{
    public partial class CiclosCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Provincias",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Provincias",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Familias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "TipoCiclos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCiclos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Ciclos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoCicloId = table.Column<int>(type: "int", nullable: false),
                    FamiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciclos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciclos_Familias_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ciclos_TipoCiclos_TipoCicloId",
                        column: x => x.TipoCicloId,
                        principalTable: "TipoCiclos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Ciclos_FamiliaId",
                table: "Ciclos",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciclos_TipoCicloId",
                table: "Ciclos",
                column: "TipoCicloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ciclos");

            migrationBuilder.DropTable(
                name: "Familias");

            migrationBuilder.DropTable(
                name: "TipoCiclos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Provincias",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Provincias",
                newName: "id");
        }
    }
}
