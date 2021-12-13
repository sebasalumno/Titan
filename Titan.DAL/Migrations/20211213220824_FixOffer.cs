using Microsoft.EntityFrameworkCore.Migrations;

namespace Titan.DAL.Migrations
{
    public partial class FixOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Empresas_EmpresaId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Offers",
                newName: "Empresaid");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_EmpresaId",
                table: "Offers",
                newName: "IX_Offers_Empresaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Empresas_Empresaid",
                table: "Offers",
                column: "Empresaid",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Empresas_Empresaid",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "Empresaid",
                table: "Offers",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_Empresaid",
                table: "Offers",
                newName: "IX_Offers_EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Empresas_EmpresaId",
                table: "Offers",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
