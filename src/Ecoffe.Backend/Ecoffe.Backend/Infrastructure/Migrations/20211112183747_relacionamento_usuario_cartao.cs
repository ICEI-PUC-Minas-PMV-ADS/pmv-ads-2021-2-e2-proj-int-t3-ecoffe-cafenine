using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class relacionamento_usuario_cartao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Cartao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_UsuarioId",
                table: "Cartao",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_Usuario_UsuarioId",
                table: "Cartao",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_Usuario_UsuarioId",
                table: "Cartao");

            migrationBuilder.DropIndex(
                name: "IX_Cartao_UsuarioId",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Cartao");
        }
    }
}
