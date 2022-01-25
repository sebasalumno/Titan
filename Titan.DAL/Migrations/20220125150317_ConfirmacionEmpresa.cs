using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Titan.DAL.Migrations
{
    public partial class ConfirmacionEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

           migrationBuilder.AddColumn<bool>(
             name: "Confirmado",
             table: "Empresas",
             type: "tinyint(1)",
             nullable: false,
             defaultValue: false);


            migrationBuilder.CreateTable(
                name: "ConfirmacionesE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmacionesE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmacionesE_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmacionesE_IdEmpresa",
                table: "ConfirmacionesE",
                column: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmacionesE");
        }
    }
}
