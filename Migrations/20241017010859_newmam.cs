using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoVagas.Migrations
{
    public partial class newmam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Vagas");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Vagas",
                newName: "Location_DisplayName");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Vagas",
                newName: "Company_DisplayName");

            migrationBuilder.AddColumn<string>(
                name: "Category_Label",
                table: "Vagas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_Label",
                table: "Vagas");

            migrationBuilder.RenameColumn(
                name: "Location_DisplayName",
                table: "Vagas",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Company_DisplayName",
                table: "Vagas",
                newName: "Company");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Vagas",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }
    }
}
