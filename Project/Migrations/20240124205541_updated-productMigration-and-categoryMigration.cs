using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Art_Gallery.Migrations
{
    public partial class updatedproductMigrationandcategoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_productTbs_cat_id",
                table: "productTbs",
                column: "cat_id");

            migrationBuilder.AddForeignKey(
                name: "FK_productTbs_categoryTb_cat_id",
                table: "productTbs",
                column: "cat_id",
                principalTable: "categoryTb",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productTbs_categoryTb_cat_id",
                table: "productTbs");

            migrationBuilder.DropIndex(
                name: "IX_productTbs_cat_id",
                table: "productTbs");
        }
    }
}
