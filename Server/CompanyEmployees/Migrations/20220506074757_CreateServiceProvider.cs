using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMuthurajApi.Migrations
{
    public partial class CreateServiceProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f56e948-3282-4b38-a120-5e733ec55275");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f27c6597-f390-4c3b-8aa4-dba4ebc98f48");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.CreateTable(
                name: "ServiceProviders",
                columns: table => new
                {
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceProviderName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ServiceProviderAdd1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ServiceProviderAdd2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ServiceProviderState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ServiceProviderCity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ServiceProviderRegNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceProviderPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceProviderEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceProviderWebsite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedbyId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version_No = table.Column<int>(type: "int", nullable: false),
                    ISActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviders", x => x.ServiceProviderId);
                    table.ForeignKey(
                        name: "FK_ServiceProviders_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59724adf-90ff-4450-b3d4-6f5115c49c66", "8a0c8330-644e-4b3f-9838-0a5573d1680a", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "afea6346-4fa2-450a-8c36-586dc6354360", "7c60a1ae-69c8-4fd4-a667-a223620de8c3", "Manager", "MANAGER" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_CountryId",
                table: "ServiceProviders",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59724adf-90ff-4450-b3d4-6f5115c49c66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afea6346-4fa2-450a-8c36-586dc6354360");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "CountryId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f56e948-3282-4b38-a120-5e733ec55275", "01c5c57a-3bac-4f22-9b6c-06fd98af5628", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f27c6597-f390-4c3b-8aa4-dba4ebc98f48", "bae5af0f-17cd-4cb0-8351-14b36f24d82e", "Manager", "MANAGER" });
        }
    }
}
