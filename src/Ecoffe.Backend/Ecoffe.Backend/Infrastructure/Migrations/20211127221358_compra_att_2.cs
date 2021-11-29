using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class compra_att_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "ProdutoCompra");

            migrationBuilder.RenameColumn(
                name: "ValorParcelas",
                table: "Compra",
                newName: "ValorParcela");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorParcela",
                table: "Compra",
                newName: "ValorParcelas");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "ProdutoCompra",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
