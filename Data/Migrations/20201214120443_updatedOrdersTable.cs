using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updatedOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlatformId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderPlatform",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Platform = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPlatform", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PlatformId",
                table: "Orders",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderPlatform_PlatformId",
                table: "Orders",
                column: "PlatformId",
                principalTable: "OrderPlatform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderPlatform_PlatformId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BookImages");

            migrationBuilder.DropTable(
                name: "OrderPlatform");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PlatformId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Orders");
        }
    }
}
