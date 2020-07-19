using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityZNetCore.Migrations
{
    public partial class AddRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Region",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemData",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TemData",
                table: "AspNetUsers");
        }
    }
}
