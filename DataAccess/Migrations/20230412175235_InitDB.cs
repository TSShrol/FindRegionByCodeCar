using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRegion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarNumberCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarNumberCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarNumberCodes_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "NameRegion" },
                values: new object[,]
                {
                    { 1, "Рівненська" },
                    { 2, "Волинська" },
                    { 3, "Житомирська" },
                    { 4, "Львівська" }
                });

            migrationBuilder.InsertData(
                table: "CarNumberCodes",
                columns: new[] { "Id", "Code", "RegionId" },
                values: new object[,]
                {
                    { 1, "BK", 1 },
                    { 2, "HK", 1 },
                    { 3, "AC", 2 },
                    { 4, "KC", 2 },
                    { 5, "AM", 3 },
                    { 6, "KM", 3 },
                    { 7, "BC", 4 },
                    { 8, "HC", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarNumberCodes_RegionId",
                table: "CarNumberCodes",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarNumberCodes");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
