using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoVagas.Migrations
{
    public partial class novassy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_Label",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Company_DisplayName",
                table: "Vagas");

            migrationBuilder.RenameColumn(
                name: "Location_DisplayName",
                table: "Vagas",
                newName: "Display_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Display_name",
                table: "Vagas",
                newName: "Location_DisplayName");

            migrationBuilder.AddColumn<string>(
                name: "Category_Label",
                table: "Vagas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company_DisplayName",
                table: "Vagas",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}
