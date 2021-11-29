using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class carrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarrinhoId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carrinho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoProduto",
                columns: table => new
                {
                    CarrinhosId = table.Column<int>(type: "int", nullable: false),
                    ProdutosId_Produto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoProduto", x => new { x.CarrinhosId, x.ProdutosId_Produto });
                    table.ForeignKey(
                        name: "FK_CarrinhoProduto_Carrinho_CarrinhosId",
                        column: x => x.CarrinhosId,
                        principalTable: "Carrinho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrinhoProduto_Produto_ProdutosId_Produto",
                        column: x => x.ProdutosId_Produto,
                        principalTable: "Produto",
                        principalColumn: "Id_Produto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CarrinhoId",
                table: "Usuario",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoProduto_ProdutosId_Produto",
                table: "CarrinhoProduto",
                column: "ProdutosId_Produto");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Carrinho_CarrinhoId",
                table: "Usuario",
                column: "CarrinhoId",
                principalTable: "Carrinho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Carrinho_CarrinhoId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "CarrinhoProduto");

            migrationBuilder.DropTable(
                name: "Carrinho");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_CarrinhoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Usuario");
        }
    }
}
