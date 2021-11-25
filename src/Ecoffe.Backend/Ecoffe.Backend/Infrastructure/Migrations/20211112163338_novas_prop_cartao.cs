using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    public partial class novas_prop_cartao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Cartao",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdicao",
                table: "Cartao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Principal",
                table: "Cartao",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAdicao",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "Principal",
                table: "Cartao");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Cartao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
