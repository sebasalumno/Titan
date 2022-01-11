using Microsoft.EntityFrameworkCore.Migrations;

namespace Titan.DAL.Migrations
{
    public partial class inscripciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_OfferEmpresas_OfertaId",
                table: "Inscripciones");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_AlumnoId",
                table: "Inscripciones",
                column: "AlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Offers_OfertaId",
                table: "Inscripciones",
                column: "OfertaId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Usuarios_AlumnoId",
                table: "Inscripciones",
                column: "AlumnoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Offers_OfertaId",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Usuarios_AlumnoId",
                table: "Inscripciones");

            migrationBuilder.DropIndex(
                name: "IX_Inscripciones_AlumnoId",
                table: "Inscripciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_OfferEmpresas_OfertaId",
                table: "Inscripciones",
                column: "OfertaId",
                principalTable: "OfferEmpresas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
