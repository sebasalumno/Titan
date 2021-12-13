using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Titan.DAL.Migrations
{
    public partial class OffersCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Ciclos_cicloId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_cicloId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "cicloId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Offers",
                newName: "Nombre");



            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Fin",
                table: "Offers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Inicio",
                table: "Offers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Idciclo",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_Idciclo",
                table: "Offers",
                column: "Idciclo");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Ciclos_Idciclo",
                table: "Offers",
                column: "Idciclo",
                principalTable: "Ciclos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Ciclos_Idciclo",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_Idciclo",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Fecha_Fin",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Fecha_Inicio",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Idciclo",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Offers",
                newName: "name");

            migrationBuilder.AddColumn<int>(
                name: "cicloId",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_cicloId",
                table: "Offers",
                column: "cicloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Ciclos_cicloId",
                table: "Offers",
                column: "cicloId",
                principalTable: "Ciclos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
