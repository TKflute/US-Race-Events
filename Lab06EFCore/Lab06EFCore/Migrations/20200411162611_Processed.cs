using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab06EFCore.Migrations
{
    public partial class Processed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Processed",
                table: "Registrations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Processed",
                table: "Registrations");
        }
    }
}
