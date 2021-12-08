using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Titan.DAL.Migrations
{
    public partial class ciclosAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = @"../Titan.DAl/Scripts/20211208_InsertarCiclos.sql";
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from ciclos;");
        }
    }
}
