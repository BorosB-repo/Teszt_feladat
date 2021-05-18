using Microsoft.EntityFrameworkCore.Migrations;

namespace Teszt_feladat.Migrations
{
    public partial class rename_property_myprop_to_date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Measurements",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Measurements",
                newName: "MyProperty");
        }
    }
}
