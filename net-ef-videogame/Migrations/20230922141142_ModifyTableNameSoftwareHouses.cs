using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    public partial class ModifyTableNameSoftwareHouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_SoftwareHouses_software_house_id",
                table: "videogames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareHouses",
                table: "SoftwareHouses");

            migrationBuilder.RenameTable(
                name: "SoftwareHouses",
                newName: "software_houses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_software_houses",
                table: "software_houses",
                column: "software_house_id");

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_software_houses_software_house_id",
                table: "videogames",
                column: "software_house_id",
                principalTable: "software_houses",
                principalColumn: "software_house_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_software_houses_software_house_id",
                table: "videogames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_software_houses",
                table: "software_houses");

            migrationBuilder.RenameTable(
                name: "software_houses",
                newName: "SoftwareHouses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoftwareHouses",
                table: "SoftwareHouses",
                column: "software_house_id");

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_SoftwareHouses_software_house_id",
                table: "videogames",
                column: "software_house_id",
                principalTable: "SoftwareHouses",
                principalColumn: "software_house_id");
        }
    }
}
