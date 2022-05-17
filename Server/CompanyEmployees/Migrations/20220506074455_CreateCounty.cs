using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMuthurajApi.Migrations
{
    public partial class CreateCounty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92b2eda9-4bb7-4608-a4e0-c152abe19048");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c88c7f1f-413f-4d57-a991-8e681e16dd49");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumericCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NativeNameOfficial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NativeNameCommon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Tld = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CIOC_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CallingCodeRoot = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CallingCodeSuffix = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Capitol = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SubRegion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FlagCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MapGoogle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MapOpenStreetMap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TimrZone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FlagPng = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FlagSVG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CoatOfArmspng = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CoatOfArmssvg = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StartOfWeek = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CapitalInfolatlng = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCodeformat = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostalCoderegex = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedbyId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version_No = table.Column<int>(type: "int", nullable: false),
                    ISActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f56e948-3282-4b38-a120-5e733ec55275", "01c5c57a-3bac-4f22-9b6c-06fd98af5628", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f27c6597-f390-4c3b-8aa4-dba4ebc98f48", "bae5af0f-17cd-4cb0-8351-14b36f24d82e", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f56e948-3282-4b38-a120-5e733ec55275");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f27c6597-f390-4c3b-8aa4-dba4ebc98f48");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92b2eda9-4bb7-4608-a4e0-c152abe19048", "2754ed64-3842-4e22-a79f-5e0ecd5d8f43", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c88c7f1f-413f-4d57-a991-8e681e16dd49", "44164b07-c323-43f6-ade7-2704d81dc89f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
