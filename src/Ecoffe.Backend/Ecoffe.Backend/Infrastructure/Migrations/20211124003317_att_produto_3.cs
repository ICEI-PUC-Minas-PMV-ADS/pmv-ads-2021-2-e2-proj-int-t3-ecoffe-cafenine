using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class att_produto_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoProduto");

            migrationBuilder.AddColumn<int>(
                name: "CarrinhoId",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CarrinhoId",
                table: "Produto",
                column: "CarrinhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Carrinho_CarrinhoId",
                table: "Produto",
                column: "CarrinhoId",
                principalTable: "Carrinho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Carrinho_CarrinhoId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_CarrinhoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Produto");

            migrationBuilder.CreateTable(
                name: "CarrinhoProduto",
                columns: table => new
                {
                    CarrinhosId = table.Column<int>(type: "int", nullable: false),
                    ProdutosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoProduto", x => new { x.CarrinhosId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_CarrinhoProduto_Carrinho_CarrinhosId",
                        column: x => x.CarrinhosId,
                        principalTable: "Carrinho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrinhoProduto_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoProduto_ProdutosId",
                table: "CarrinhoProduto",
                column: "ProdutosId");
        }
    }
}
