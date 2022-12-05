using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class change_lang_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Languages_languageID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookLanguageID",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "languageID",
                table: "Books",
                newName: "LanguageID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_languageID",
                table: "Books",
                newName: "IX_Books_LanguageID");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageID",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Languages_LanguageID",
                table: "Books",
                column: "LanguageID",
                principalTable: "Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Languages_LanguageID",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "LanguageID",
                table: "Books",
                newName: "languageID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_LanguageID",
                table: "Books",
                newName: "IX_Books_languageID");

            migrationBuilder.AlterColumn<int>(
                name: "languageID",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BookLanguageID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Languages_languageID",
                table: "Books",
                column: "languageID",
                principalTable: "Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
