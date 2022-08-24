using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebProje.Migrations
{
    public partial class ProductFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    companyProfile = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Catagory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    availability = table.Column<bool>(type: "boolean", nullable: false),
                    sale = table.Column<bool>(type: "boolean", nullable: false),
                    Brand = table.Column<int>(type: "integer", nullable: true),
                    Catagory = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_Brand",
                        column: x => x.Brand,
                        principalTable: "Brand",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Product_Catagory_Catagory",
                        column: x => x.Catagory,
                        principalTable: "Catagory",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Brand",
                table: "Product",
                column: "Brand");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Catagory",
                table: "Product",
                column: "Catagory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Catagory");
        }
    }
}
