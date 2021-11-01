using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class atualizacoes_usuario_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId_Usuario",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_enderecoId_Endereco",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Id_Endereco",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "tx_Email",
                table: "Usuario",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "enderecoId_Endereco",
                table: "Usuario",
                newName: "EnderecoId");

            migrationBuilder.RenameColumn(
                name: "Tx_Senha",
                table: "Usuario",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "Tx_Cpf",
                table: "Usuario",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Nr_telefone",
                table: "Usuario",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Nm_Usuario",
                table: "Usuario",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "In_Ativo",
                table: "Usuario",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "In_Admin",
                table: "Usuario",
                newName: "Admin");

            migrationBuilder.RenameColumn(
                name: "Id_Usuario",
                table: "Usuario",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_enderecoId_Endereco",
                table: "Usuario",
                newName: "IX_Usuario_EnderecoId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId_Usuario",
                table: "Pedido",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_UsuarioId_Usuario",
                table: "Pedido",
                newName: "IX_Pedido_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId",
                table: "Pedido",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id_Endereco",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Usuario",
                newName: "tx_Email");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuario",
                newName: "Tx_Senha");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Usuario",
                newName: "Tx_Cpf");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Usuario",
                newName: "enderecoId_Endereco");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuario",
                newName: "Nr_telefone");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Usuario",
                newName: "Nm_Usuario");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Usuario",
                newName: "In_Ativo");

            migrationBuilder.RenameColumn(
                name: "Admin",
                table: "Usuario",
                newName: "In_Admin");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuario",
                newName: "Id_Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario",
                newName: "IX_Usuario_enderecoId_Endereco");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Pedido",
                newName: "UsuarioId_Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedido",
                newName: "IX_Pedido_UsuarioId_Usuario");

            migrationBuilder.AddColumn<int>(
                name: "Id_Endereco",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId_Usuario",
                table: "Pedido",
                column: "UsuarioId_Usuario",
                principalTable: "Usuario",
                principalColumn: "Id_Usuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_enderecoId_Endereco",
                table: "Usuario",
                column: "enderecoId_Endereco",
                principalTable: "Endereco",
                principalColumn: "Id_Endereco",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
