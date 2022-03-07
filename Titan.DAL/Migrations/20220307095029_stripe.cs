using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Titan.DAL.Migrations
{
    public partial class stripe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Rol_RolId",
                table: "Empresas");




            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");





            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roles");




            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Mensajes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Mensajes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContratoEstados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoEstados", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ContratoEstadoId = table.Column<int>(type: "int", nullable: false),
                    StripeId = table.Column<int>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_ContratoEstados_ContratoEstadoId",
                        column: x => x.ContratoEstadoId,
                        principalTable: "ContratoEstados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    StripePriceId = table.Column<int>(type: "longtext", nullable: false),
                    ContratoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ContratoEstadoId",
                table: "Contratos",
                column: "ContratoEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ContratoId",
                table: "Facturas",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_EmpresaId",
                table: "Facturas",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Roles_RolId",
                table: "Empresas",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Roles_RolId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensajes_Empresas_EmpresaId",
                table: "Mensajes");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensajes_Usuarios_UsuarioId",
                table: "Mensajes");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "ContratoEstados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Rol");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Mensajes",
                newName: "usuarioId");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Mensajes",
                newName: "empresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Mensajes_UsuarioId",
                table: "Mensajes",
                newName: "IX_Mensajes_usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Mensajes_EmpresaId",
                table: "Mensajes",
                newName: "IX_Mensajes_empresaId");

            migrationBuilder.AlterColumn<int>(
                name: "usuarioId",
                table: "Mensajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "empresaId",
                table: "Mensajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Mensajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Mensajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Rol_RolId",
                table: "Empresas",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensajes_Empresas_empresaId",
                table: "Mensajes",
                column: "empresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensajes_Usuarios_usuarioId",
                table: "Mensajes",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
