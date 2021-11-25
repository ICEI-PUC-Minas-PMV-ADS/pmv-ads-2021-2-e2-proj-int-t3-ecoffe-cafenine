using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class att_produto_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoProduto_Produto_ProdutosId_Produto",
                table: "CarrinhoProduto");

            migrationBuilder.DropColumn(
                name: "Nm_Produto",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "Vl_Preco_Produto",
                table: "Produto",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "Nr_Peso_Liquido",
                table: "Produto",
                newName: "Peso");

            migrationBuilder.RenameColumn(
                name: "Nr_Largura",
                table: "Produto",
                newName: "Largura");

            migrationBuilder.RenameColumn(
                name: "Nr_Altura",
                table: "Produto",
                newName: "Altura");

            migrationBuilder.RenameColumn(
                name: "Id_Produto",
                table: "Produto",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProdutosId_Produto",
                table: "CarrinhoProduto",
                newName: "ProdutosId");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoProduto_ProdutosId_Produto",
                table: "CarrinhoProduto",
                newName: "IX_CarrinhoProduto_ProdutosId");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoProduto_Produto_ProdutosId",
                table: "CarrinhoProduto",
                column: "ProdutosId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoProduto_Produto_ProdutosId",
                table: "CarrinhoProduto");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Produto",
                newName: "Vl_Preco_Produto");

            migrationBuilder.RenameColumn(
                name: "Peso",
                table: "Produto",
                newName: "Nr_Peso_Liquido");

            migrationBuilder.RenameColumn(
                name: "Largura",
                table: "Produto",
                newName: "Nr_Largura");

            migrationBuilder.RenameColumn(
                name: "Altura",
                table: "Produto",
                newName: "Nr_Altura");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Produto",
                newName: "Id_Produto");

            migrationBuilder.RenameColumn(
                name: "ProdutosId",
                table: "CarrinhoProduto",
                newName: "ProdutosId_Produto");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoProduto_ProdutosId",
                table: "CarrinhoProduto",
                newName: "IX_CarrinhoProduto_ProdutosId_Produto");

            migrationBuilder.AddColumn<string>(
                name: "Nm_Produto",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoProduto_Produto_ProdutosId_Produto",
                table: "CarrinhoProduto",
                column: "ProdutosId_Produto",
                principalTable: "Produto",
                principalColumn: "Id_Produto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
