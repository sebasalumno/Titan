using Microsoft.EntityFrameworkCore.Migrations;

namespace Titan.DAL.Migrations
{
    public partial class inscripciones_oferta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_OfertaId",
                table: "Inscripciones",
                column: "OfertaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Offers_OfertaId",
                table: "Inscripciones",
                column: "OfertaId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Offers_OfertaId",
                table: "Inscripciones");

            migrationBuilder.DropIndex(
                name: "IX_Inscripciones_OfertaId",
                table: "Inscripciones");
        }
    }
}
