using Microsoft.EntityFrameworkCore.Migrations;

namespace CWitter.Migrations
{
    public partial class Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Cweets");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Cweets",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cweets",
                table: "Cweets",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cweets",
                table: "Cweets");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Cweets");

            migrationBuilder.RenameTable(
                name: "Cweets",
                newName: "Blogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "ID");
        }
    }
}
