using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Id_Catao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr_Cartao = table.Column<int>(type: "int", nullable: false),
                    Dt_Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nm_Cartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tx_Bandeira = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Id_Catao);
                });

            migrationBuilder.CreateTable(
                name: "Cupom",
                columns: table => new
                {
                    Id_Cupom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vl_Cupom = table.Column<float>(type: "real", nullable: false),
                    Tx_Cupom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupom", x => x.Id_Cupom);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id_Endereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tx_Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nr_Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nr_Cep = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id_Endereco);
                });

            migrationBuilder.CreateTable(
                name: "EtapaVenda",
                columns: table => new
                {
                    Id_Etapa_Venda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tx_Nome_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaVenda", x => x.Id_Etapa_Venda);
                });

            migrationBuilder.CreateTable(
                name: "Frete",
                columns: table => new
                {
                    Id_Frete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vl_Frete = table.Column<float>(type: "real", nullable: false),
                    Nm_Status_Frete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Status_Frete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frete", x => x.Id_Frete);
                });

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

            migrationBuilder.CreateTable(
                name: "Seguranca",
                columns: table => new
                {
                    Id_Cod_Seguranca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Seguranca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguranca", x => x.Id_Cod_Seguranca);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tx_Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tx_Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tx_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Endereco = table.Column<int>(type: "int", nullable: false),
                    Tx_Cnpj = table.Column<int>(type: "int", nullable: false),
                    Id_Cartao = table.Column<int>(type: "int", nullable: false),
                    CartaoId_Catao = table.Column<int>(type: "int", nullable: true),
                    Nr_telefone = table.Column<int>(type: "int", nullable: false),
                    In_Ativo = table.Column<bool>(type: "bit", nullable: false),
                    In_Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Cartao_CartaoId_Catao",
                        column: x => x.CartaoId_Catao,
                        principalTable: "Cartao",
                        principalColumn: "Id_Catao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id_Pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DT_Pedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConfirmacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PesoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioId_Usuario = table.Column<int>(type: "int", nullable: true),
                    Id_Cupom = table.Column<int>(type: "int", nullable: true),
                    CupomId_Cupom = table.Column<int>(type: "int", nullable: true),
                    Id_NotaFiscal = table.Column<int>(type: "int", nullable: false),
                    NotaFiscalId_NotaFiscal = table.Column<int>(type: "int", nullable: true),
                    Id_Frete = table.Column<int>(type: "int", nullable: false),
                    FreteId_Frete = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Pedido_Usuario_UsuarioId_Usuario",
                        column: x => x.UsuarioId_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id_Produto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm_Produto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nr_Peso_Liquido = table.Column<float>(type: "real", nullable: false),
                    Nr_Altura = table.Column<float>(type: "real", nullable: false),
                    Nr_Largura = table.Column<float>(type: "real", nullable: false),
                    Tx_Informacao_Comercial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vl_Preco_Produto = table.Column<float>(type: "real", nullable: false),
                    PedidoId_Pedido = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id_Produto);
                    table.ForeignKey(
                        name: "FK_Produto_Pedido_PedidoId_Pedido",
                        column: x => x.PedidoId_Pedido,
                        principalTable: "Pedido",
                        principalColumn: "Id_Pedido",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Pedido_UsuarioId_Usuario",
                table: "Pedido",
                column: "UsuarioId_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PedidoId_Pedido",
                table: "Produto",
                column: "PedidoId_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CartaoId_Catao",
                table: "Usuario",
                column: "CartaoId_Catao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "EtapaVenda");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Seguranca");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Cupom");

            migrationBuilder.DropTable(
                name: "Frete");

            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cartao");
        }
    }
}
