using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoVagas.Migrations
{
    public partial class novass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RedirectUrl",
                table: "Vagas",
                newName: "Redirect_url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Redirect_url",
                table: "Vagas",
                newName: "RedirectUrl");
        }
    }
}
