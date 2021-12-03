using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class removendo_frete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frete",
                columns: table => new
                {
                    Id_Frete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Status_Frete = table.Column<int>(type: "int", nullable: false),
                    Nm_Status_Frete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vl_Frete = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frete", x => x.Id_Frete);
                });
        }
    }
}
