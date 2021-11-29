using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class ajustes_cartao_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nm_Cartao",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "Tx_Bandeira",
                table: "Cartao");

            migrationBuilder.RenameColumn(
                name: "Nr_Cartao",
                table: "Cartao",
                newName: "TipoCartao");

            migrationBuilder.RenameColumn(
                name: "Dt_Validade",
                table: "Cartao",
                newName: "Vencimento");

            migrationBuilder.AddColumn<string>(
                name: "Bandeira",
                table: "Cartao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CpfTitular",
                table: "Cartao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Csv",
                table: "Cartao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeTitular",
                table: "Cartao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Cartao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bandeira",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "CpfTitular",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "Csv",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "NomeTitular",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Cartao");

            migrationBuilder.RenameColumn(
                name: "Vencimento",
                table: "Cartao",
                newName: "Dt_Validade");

            migrationBuilder.RenameColumn(
                name: "TipoCartao",
                table: "Cartao",
                newName: "Nr_Cartao");

            migrationBuilder.AddColumn<string>(
                name: "Nm_Cartao",
                table: "Cartao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tx_Bandeira",
                table: "Cartao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
