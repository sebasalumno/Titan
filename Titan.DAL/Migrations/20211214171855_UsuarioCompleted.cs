using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Titan.DAL.Migrations
{
    public partial class UsuarioCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CicloId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Usuarios",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Usuarios",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Usuarios",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TipoCicloId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "nota",
                table: "Usuarios",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CicloId",
                table: "Usuarios",
                column: "CicloId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoCicloId",
                table: "Usuarios",
                column: "TipoCicloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Ciclos_CicloId",
                table: "Usuarios",
                column: "CicloId",
                principalTable: "Ciclos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoCiclos_TipoCicloId",
                table: "Usuarios",
                column: "TipoCicloId",
                principalTable: "TipoCiclos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Ciclos_CicloId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoCiclos_TipoCicloId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CicloId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TipoCicloId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CicloId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoCicloId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "nota",
                table: "Usuarios");
        }
    }
}
