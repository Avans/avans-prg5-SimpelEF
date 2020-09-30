using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Woningen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Woningen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bewoners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    WoningId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bewoners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bewoners_Woningen_WoningId",
                        column: x => x.WoningId,
                        principalTable: "Woningen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Woningen",
                columns: new[] { "Id", "Naam" },
                values: new object[] { 2, "zelftevree" });

            migrationBuilder.InsertData(
                table: "Woningen",
                columns: new[] { "Id", "Naam" },
                values: new object[] { 3, "boslust" });

            migrationBuilder.InsertData(
                table: "Bewoners",
                columns: new[] { "Id", "Naam", "WoningId" },
                values: new object[,]
                {
                    { 1, "Joosten", 2 },
                    { 2, "Verschoor", 2 },
                    { 3, "Rubens", 3 },
                    { 4, "Van Zanten", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bewoners_WoningId",
                table: "Bewoners",
                column: "WoningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bewoners");

            migrationBuilder.DropTable(
                name: "Woningen");
        }
    }
}
