using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    public partial class NoMoreCompProf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companyProfile",
                table: "Brand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "companyProfile",
                table: "Brand",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
