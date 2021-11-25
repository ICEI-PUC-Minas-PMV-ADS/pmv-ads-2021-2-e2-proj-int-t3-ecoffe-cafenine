using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class atualizacoes_endereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nr_Cep",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Nr_Endereco",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Tx_Endereco",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "Id_Endereco",
                table: "Endereco",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Endereco",
                newName: "Id_Endereco");

            migrationBuilder.AddColumn<string>(
                name: "Nr_Cep",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nr_Endereco",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tx_Endereco",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
