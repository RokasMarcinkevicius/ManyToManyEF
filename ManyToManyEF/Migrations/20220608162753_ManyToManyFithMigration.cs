using Microsoft.EntityFrameworkCore.Migrations;

namespace ManyToManyEF.Migrations
{
    public partial class ManyToManyFithMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternatePath",
                table: "Folders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternatePath",
                table: "Folders");
        }
    }
}
