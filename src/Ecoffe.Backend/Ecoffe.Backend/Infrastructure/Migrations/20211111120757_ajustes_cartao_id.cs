using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class ajustes_cartao_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Catao",
                table: "Cartao",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cartao",
                newName: "Id_Catao");
        }
    }
}
