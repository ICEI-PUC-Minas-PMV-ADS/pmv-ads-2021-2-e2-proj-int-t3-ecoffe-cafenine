using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class att_produtocarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProdutoCarrinho_ProdutoId",
                table: "ProdutoCarrinho",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoCarrinho_Produto_ProdutoId",
                table: "ProdutoCarrinho",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoCarrinho_Produto_ProdutoId",
                table: "ProdutoCarrinho");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoCarrinho_ProdutoId",
                table: "ProdutoCarrinho");
        }
    }
}
