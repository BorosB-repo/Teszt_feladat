using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teszt_feladat.Migrations
{
    public partial class addTables_measurement_measurementpoint_shop_updateTable_vechiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementPoints",
                columns: table => new
                {
                    MeasurementPointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementPoints", x => x.MeasurementPointId);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopId);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VechicleId = table.Column<int>(type: "int", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    MeasurementPointId = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<DateTime>(type: "datetime", nullable: false),
                    Gap = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    Flush = table.Column<decimal>(type: "decimal(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurements_MeasurementPoints_MeasurementPointId",
                        column: x => x.MeasurementPointId,
                        principalTable: "MeasurementPoints",
                        principalColumn: "MeasurementPointId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Measurements_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Measurements_Vechicles_VechicleId",
                        column: x => x.VechicleId,
                        principalTable: "Vechicles",
                        principalColumn: "VechicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_MeasurementPointId",
                table: "Measurements",
                column: "MeasurementPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_ShopId",
                table: "Measurements",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_VechicleId",
                table: "Measurements",
                column: "VechicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "MeasurementPoints");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
