using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesForFree.Data.Migrations
{
    public partial class RemoveCreatedDateEntirely : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VideoGame");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CompanyVideoGame");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CompanyType");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Company");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "VideoGame",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "CompanyVideoGame",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "CompanyType",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Company",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2018, 11, 25, 17, 5, 9, 274, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2018, 11, 25, 17, 5, 9, 274, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2018, 11, 25, 17, 5, 9, 269, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)));
        }
    }
}
