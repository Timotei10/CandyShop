using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandyShop.Migrations
{
    public partial class origin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Origin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_OriginID",
                table: "Product",
                column: "OriginID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Origin_OriginID",
                table: "Product",
                column: "OriginID",
                principalTable: "Origin",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Origin_OriginID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Origin");

            migrationBuilder.DropIndex(
                name: "IX_Product_OriginID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OriginID",
                table: "Product");
        }
    }
}
