using Microsoft.EntityFrameworkCore.Migrations;

namespace NYourCodeAsCrimeScene.Infrastructure.Migrations
{
    public partial class AddedLengthToFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "GitFile",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "GitFile");
        }
    }
}
