﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace NYourCodeAsCrimeScene.Infrastructure.Migrations
{
    public partial class AddedProjectColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Projects");
        }
    }
}
