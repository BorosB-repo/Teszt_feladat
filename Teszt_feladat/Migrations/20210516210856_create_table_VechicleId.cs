using Microsoft.EntityFrameworkCore.Migrations;

namespace Teszt_feladat.Migrations
{
    public partial class create_table_VechicleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vechicles",
                columns: table => new
                {
                    VechicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JSN = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    VechicleModel = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vechicles", x => x.VechicleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vechicles");
        }
    }
}
