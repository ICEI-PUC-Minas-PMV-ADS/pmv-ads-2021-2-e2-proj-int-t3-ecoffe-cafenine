using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class atualizacoesusuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tx_Cnpj",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Nr_telefone",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "enderecoId_Endereco",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_enderecoId_Endereco",
                table: "Usuario",
                column: "enderecoId_Endereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_enderecoId_Endereco",
                table: "Usuario",
                column: "enderecoId_Endereco",
                principalTable: "Endereco",
                principalColumn: "Id_Endereco",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_enderecoId_Endereco",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_enderecoId_Endereco",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "enderecoId_Endereco",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "Nr_telefone",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tx_Cnpj",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
