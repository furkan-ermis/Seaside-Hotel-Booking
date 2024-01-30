using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DestinyHaven.Migrations
{
    public partial class updateTestimonials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_AspNetUsers_AppUserId",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Testimonials");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Testimonials",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_AspNetUsers_AppUserId",
                table: "Testimonials",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_AspNetUsers_AppUserId",
                table: "Testimonials");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Testimonials",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_AspNetUsers_AppUserId",
                table: "Testimonials",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
