using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoVagas.Migrations
{
    public partial class novamigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalheVagas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Vagas");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Vagas",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Localizacao",
                table: "Vagas",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "Vagas",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Vagas",
                type: "datetime2",
                maxLength: 1000,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vagas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Redirect_url",
                table: "Vagas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Vagas",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Redirect_url",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Vagas");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Vagas",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Vagas",
                newName: "Localizacao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vagas",
                newName: "codigo");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Vagas",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Vagas",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetalheVagas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DescricaoCompleta = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    Localizacao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheVagas", x => x.Id);
                });
        }
    }
}
