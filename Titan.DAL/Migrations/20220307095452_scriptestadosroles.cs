using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Titan.DAL.Migrations
{
    public partial class scriptestadosroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = @"../Titan.DAl/Scripts/20220307_InsertarContratoEstados.sql";
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
            sqlFile = @"../Titan.DAl/Scripts/20220307_InsertarRoles.sql";
            migrationBuilder.Sql(File.ReadAllText(sqlFile));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
