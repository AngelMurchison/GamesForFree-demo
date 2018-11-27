using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesForFree.Data.Migrations
{
    public partial class ReplacedPublisherWithCompany_MadeVideoGameCompanyRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGame_Publisher_PublisherId",
                table: "VideoGame");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_VideoGame_PublisherId",
                table: "VideoGame");

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

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "VideoGame");

            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    VideoGameId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    GamePointsExchanged = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_VideoGame_VideoGameId",
                        column: x => x.VideoGameId,
                        principalTable: "VideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CompanyTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_CompanyType_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyVideoGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    VideoGameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyVideoGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyVideoGame_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyVideoGame_VideoGame_VideoGameId",
                        column: x => x.VideoGameId,
                        principalTable: "VideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 11, 25, 15, 57, 1, 36, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "password" });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyTypeId",
                table: "Company",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyVideoGame_CompanyId",
                table: "CompanyVideoGame",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyVideoGame_VideoGameId",
                table: "CompanyVideoGame",
                column: "VideoGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CustomerId",
                table: "Transaction",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_VideoGameId",
                table: "Transaction",
                column: "VideoGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyVideoGame");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "CompanyType");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "VideoGame",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Electronic Arts" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 11, 22, 19, 24, 3, 371, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "s0l0d0l0" });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "AvailableForPurchase", "CreatedDate", "Description", "Price", "PublisherId", "ReleaseDate", "Title" },
                values: new object[] { 1, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0m, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Battlefield 4" });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "AvailableForPurchase", "CreatedDate", "Description", "Price", "PublisherId", "ReleaseDate", "Title" },
                values: new object[] { 2, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0m, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Battlefield 5" });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "AvailableForPurchase", "CreatedDate", "Description", "Price", "PublisherId", "ReleaseDate", "Title" },
                values: new object[] { 3, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0m, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Battlefield 1" });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_PublisherId",
                table: "VideoGame",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGame_Publisher_PublisherId",
                table: "VideoGame",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
