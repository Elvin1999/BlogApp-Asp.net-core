using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.WebUI.Migrations
{
    public partial class AddColumnSlider12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSlider",
                table: "Blogs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSlider",
                table: "Blogs");
        }
    }
}
