using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab06EFCore.Migrations
{
    public partial class RegistrationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Registrations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Registrations");
        }
    }
}
