using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class removendo_notafiscal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaFiscal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    Id_NotaFiscal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NR_NOTA_FISCAL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XML = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscal", x => x.Id_NotaFiscal);
                });
        }
    }
}
