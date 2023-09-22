using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoftwareHouses",
                columns: table => new
                {
                    software_house_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tax_id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareHouses", x => x.software_house_id);
                });

            migrationBuilder.CreateTable(
                name: "videogames",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    overwiev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    software_house_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videogames", x => x.id);
                    table.ForeignKey(
                        name: "FK_videogames_SoftwareHouses_software_house_id",
                        column: x => x.software_house_id,
                        principalTable: "SoftwareHouses",
                        principalColumn: "software_house_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_videogames_software_house_id",
                table: "videogames",
                column: "software_house_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "videogames");

            migrationBuilder.DropTable(
                name: "SoftwareHouses");
        }
    }
}
