using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesForFree.Data.Migrations
{
    public partial class seed0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Electronic Arts" });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "AvailableForPurchase", "Description", "Price", "PublisherId", "ReleaseDate", "Title" },
                values: new object[] { 1, false, null, 0m, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Battlefield 4" });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "AvailableForPurchase", "Description", "Price", "PublisherId", "ReleaseDate", "Title" },
                values: new object[] { 2, false, null, 0m, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Battlefield 5" });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "AvailableForPurchase", "Description", "Price", "PublisherId", "ReleaseDate", "Title" },
                values: new object[] { 3, false, null, 0m, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Battlefield 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VideoGame",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VideoGame",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VideoGame",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
