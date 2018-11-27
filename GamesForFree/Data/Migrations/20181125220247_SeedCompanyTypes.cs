using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesForFree.Data.Migrations
{
    public partial class SeedCompanyTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CompanyType",
                columns: new[] { "Id", "Code", "CreatedDate", "Name" },
                values: new object[] { 1, "DEV", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Developer" });

            migrationBuilder.InsertData(
                table: "CompanyType",
                columns: new[] { "Id", "Code", "CreatedDate", "Name" },
                values: new object[] { 2, "PUB", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Publisher" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2018, 11, 25, 17, 2, 47, 499, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2018, 11, 25, 15, 57, 1, 36, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)));
        }
    }
}
