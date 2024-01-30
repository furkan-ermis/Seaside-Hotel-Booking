using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DestinyHaven.Migrations
{
    public partial class facilityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SvgPath",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SvgPath",
                table: "Facilities");
        }
    }
}
