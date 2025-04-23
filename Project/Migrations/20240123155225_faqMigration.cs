using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Art_Gallery.Migrations
{
    public partial class faqMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "faqTb",
                columns: table => new
                {
                    faq_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faq_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faq_answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faqTb", x => x.faq_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "faqTb");
        }
    }
}
