using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NYourCodeAsCrimeScene.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GitCommit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitCommit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GitCommit_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GitFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    GitCommitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GitFile_GitCommit_GitCommitId",
                        column: x => x.GitCommitId,
                        principalTable: "GitCommit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GitFileEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GitFileId = table.Column<int>(type: "int", nullable: true),
                    FileLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitFileEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GitFileEntry_GitFile_GitFileId",
                        column: x => x.GitFileId,
                        principalTable: "GitFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GitCommit_ProjectId",
                table: "GitCommit",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GitFile_GitCommitId",
                table: "GitFile",
                column: "GitCommitId");

            migrationBuilder.CreateIndex(
                name: "IX_GitFile_Name_GitCommitId",
                table: "GitFile",
                columns: new[] { "Name", "GitCommitId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GitFileEntry_GitFileId",
                table: "GitFileEntry",
                column: "GitFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Name",
                table: "Projects",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GitFileEntry");

            migrationBuilder.DropTable(
                name: "GitFile");

            migrationBuilder.DropTable(
                name: "GitCommit");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
