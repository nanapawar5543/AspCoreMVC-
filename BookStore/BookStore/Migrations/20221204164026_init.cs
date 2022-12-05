using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(nullable: true),
                    BookAuthor = table.Column<string>(nullable: true),
                    BookDescription = table.Column<string>(nullable: true),
                    BookCategory = table.Column<string>(nullable: true),
                    BookLanguageID = table.Column<int>(nullable: false),
                    NoofPages = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    languageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Languages_languageID",
                        column: x => x.languageID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_languageID",
                table: "Books",
                column: "languageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
