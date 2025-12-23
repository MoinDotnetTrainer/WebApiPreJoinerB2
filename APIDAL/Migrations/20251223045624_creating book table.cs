using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIDAL.Migrations
{
    /// <inheritdoc />
    public partial class creatingbooktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BookCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_books", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_books_BookCode",
                table: "tbl_books",
                column: "BookCode",
                unique: true,
                filter: "[BookCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_books_BookName",
                table: "tbl_books",
                column: "BookName",
                unique: true,
                filter: "[BookName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_books");
        }
    }
}
