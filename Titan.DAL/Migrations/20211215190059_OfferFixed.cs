using Microsoft.EntityFrameworkCore.Migrations;

namespace Titan.DAL.Migrations
{
    public partial class OfferFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferEmpresas_Empresas_EmpresaId",
                table: "OfferEmpresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Ciclos_Idciclo",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_Idciclo",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Idciclo",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "OfferEmpresas",
                newName: "OfferId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferEmpresas_EmpresaId",
                table: "OfferEmpresas",
                newName: "IX_OfferEmpresas_OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferEmpresas_Offers_OfferId",
                table: "OfferEmpresas",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferEmpresas_Offers_OfferId",
                table: "OfferEmpresas");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "OfferEmpresas",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferEmpresas_OfferId",
                table: "OfferEmpresas",
                newName: "IX_OfferEmpresas_EmpresaId");

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
                name: "FK_OfferEmpresas_Empresas_EmpresaId",
                table: "OfferEmpresas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Ciclos_Idciclo",
                table: "Offers",
                column: "Idciclo",
                principalTable: "Ciclos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
