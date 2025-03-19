using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoVagas.Migrations
{
    public partial class novassyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Display_name",
                table: "Vagas",
                newName: "Location_Display_name");

            migrationBuilder.AddColumn<string>(
                name: "Company_Display_name",
                table: "Vagas",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company_Display_name",
                table: "Vagas");

            migrationBuilder.RenameColumn(
                name: "Location_Display_name",
                table: "Vagas",
                newName: "Display_name");
        }
    }
}
