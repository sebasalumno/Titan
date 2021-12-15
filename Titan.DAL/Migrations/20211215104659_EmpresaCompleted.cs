using Microsoft.EntityFrameworkCore.Migrations;

namespace Titan.DAL.Migrations
{
    public partial class EmpresaCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Empresas",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "localidad",
                table: "Empresas",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ProvinciaId",
                table: "Empresas",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Provincias_ProvinciaId",
                table: "Empresas",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Provincias_ProvinciaId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_ProvinciaId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "localidad",
                table: "Empresas");
        }
    }
}
