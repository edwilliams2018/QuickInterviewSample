using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleRepository.Context.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: true)
                }
            );

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Title", "Text" },
                values: new object[] { new Guid("0751883D-1E7D-4E97-AFBB-4857C71F24CD"), "Article 1", "Text of article 1" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Title", "Text" },
                values: new object[] { new Guid("0751883D-1E7D-4E97-AFBB-4857C71EEEEE"), "Article 2", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}