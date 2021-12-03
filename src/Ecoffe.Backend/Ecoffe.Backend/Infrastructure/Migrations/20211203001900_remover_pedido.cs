using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class remover_pedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Pedido_PedidoId_Pedido",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Produto_PedidoId_Pedido",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "PedidoId_Pedido",
                table: "Produto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId_Pedido",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id_Pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CupomId_Cupom = table.Column<int>(type: "int", nullable: true),
                    DT_Pedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConfirmacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FreteId_Frete = table.Column<int>(type: "int", nullable: true),
                    Id_Cupom = table.Column<int>(type: "int", nullable: true),
                    Id_Frete = table.Column<int>(type: "int", nullable: false),
                    Id_NotaFiscal = table.Column<int>(type: "int", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    NotaFiscalId_NotaFiscal = table.Column<int>(type: "int", nullable: true),
                    PesoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id_Pedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Cupom_CupomId_Cupom",
                        column: x => x.CupomId_Cupom,
                        principalTable: "Cupom",
                        principalColumn: "Id_Cupom",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Frete_FreteId_Frete",
                        column: x => x.FreteId_Frete,
                        principalTable: "Frete",
                        principalColumn: "Id_Frete",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_NotaFiscal_NotaFiscalId_NotaFiscal",
                        column: x => x.NotaFiscalId_NotaFiscal,
                        principalTable: "NotaFiscal",
                        principalColumn: "Id_NotaFiscal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PedidoId_Pedido",
                table: "Produto",
                column: "PedidoId_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CupomId_Cupom",
                table: "Pedido",
                column: "CupomId_Cupom");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_FreteId_Frete",
                table: "Pedido",
                column: "FreteId_Frete");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_NotaFiscalId_NotaFiscal",
                table: "Pedido",
                column: "NotaFiscalId_NotaFiscal");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedido",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Pedido_PedidoId_Pedido",
                table: "Produto",
                column: "PedidoId_Pedido",
                principalTable: "Pedido",
                principalColumn: "Id_Pedido",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
