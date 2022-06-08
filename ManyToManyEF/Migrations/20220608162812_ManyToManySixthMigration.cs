using Microsoft.EntityFrameworkCore.Migrations;

namespace ManyToManyEF.Migrations
{
    public partial class ManyToManySixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternatePath",
                table: "Folders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternatePath",
                table: "Folders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
