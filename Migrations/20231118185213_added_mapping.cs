using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    public partial class added_mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Customers_CustomerId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CustomerId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BooksCustomers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksCustomers", x => new { x.BookId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_BooksCustomers_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksCustomers_BookId",
                table: "BooksCustomers",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksCustomers_CustomerId",
                table: "BooksCustomers",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksCustomers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CustomerId",
                table: "Books",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Customers_CustomerId",
                table: "Books",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
