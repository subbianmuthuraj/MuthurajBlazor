using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMuthurajApi.Migrations
{
    public partial class CreateOtherMasters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_Countries_CountryId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_CountryId",
                table: "ServiceProviders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59724adf-90ff-4450-b3d4-6f5115c49c66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afea6346-4fa2-450a-8c36-586dc6354360");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ServiceProviders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ServiceProviders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupportMemberId",
                table: "ServiceProviders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupportTypeSLAId",
                table: "ServiceProviders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceProviderId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LicencedProducts",
                columns: table => new
                {
                    LicencedProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SupportTypeSlaId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedbyId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version_No = table.Column<int>(type: "int", nullable: false),
                    ISActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicencedProducts", x => x.LicencedProductId);
                });

            migrationBuilder.CreateTable(
                name: "SupportMembers",
                columns: table => new
                {
                    SupportMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    SupportMemberCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportMemberName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SupportMemberEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SupportMemberPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedbyId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version_No = table.Column<int>(type: "int", nullable: false),
                    ISActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportMembers", x => x.SupportMemberId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerAdd1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerAdd2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CustomerState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerCity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CustomerRegNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerWebsite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedbyId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version_No = table.Column<int>(type: "int", nullable: false),
                    ISActive = table.Column<bool>(type: "bit", nullable: false),
                    LicencedProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_LicencedProducts_LicencedProductId",
                        column: x => x.LicencedProductId,
                        principalTable: "LicencedProducts",
                        principalColumn: "LicencedProductId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedbyId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version_No = table.Column<int>(type: "int", nullable: false),
                    ISActive = table.Column<bool>(type: "bit", nullable: false),
                    LicencedProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_LicencedProducts_LicencedProductId",
                        column: x => x.LicencedProductId,
                        principalTable: "LicencedProducts",
                        principalColumn: "LicencedProductId");
                });

            migrationBuilder.CreateTable(
                name: "SupportTypeSLAs",
                columns: table => new
                {
                    SupportTypeSlaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupportTypeslaCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportTypeslaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    P1AcknowledgeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    P1ResolutionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    P2AcknowledgeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    P2ResolutionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    P3AcknowledgeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    P3ResolutionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    P4AcknowledgeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    P4ResolutionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedbyId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version_No = table.Column<int>(type: "int", nullable: false),
                    ISActive = table.Column<bool>(type: "bit", nullable: false),
                    LicencedProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTypeSLAs", x => x.SupportTypeSlaId);
                    table.ForeignKey(
                        name: "FK_SupportTypeSLAs_LicencedProducts_LicencedProductId",
                        column: x => x.LicencedProductId,
                        principalTable: "LicencedProducts",
                        principalColumn: "LicencedProductId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6fadb219-a48b-4d5d-b81c-50a6f6323377", "78d92560-5dd1-41d3-8ca2-adeea82c687e", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1433052-b9b9-420c-befb-7e8bf8cea1a4", "2068b18a-ec7d-449a-86f0-d206ed7e4afd", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_CustomerId",
                table: "ServiceProviders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_ProductId",
                table: "ServiceProviders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_SupportMemberId",
                table: "ServiceProviders",
                column: "SupportMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_SupportTypeSLAId",
                table: "ServiceProviders",
                column: "SupportTypeSLAId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CustomerId",
                table: "Countries",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ServiceProviderId",
                table: "Countries",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LicencedProductId",
                table: "Customers",
                column: "LicencedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LicencedProductId",
                table: "Products",
                column: "LicencedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTypeSLAs_LicencedProductId",
                table: "SupportTypeSLAs",
                column: "LicencedProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Customers_CustomerId",
                table: "Countries",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_ServiceProviders_ServiceProviderId",
                table: "Countries",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_Customers_CustomerId",
                table: "ServiceProviders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_Products_ProductId",
                table: "ServiceProviders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_SupportMembers_SupportMemberId",
                table: "ServiceProviders",
                column: "SupportMemberId",
                principalTable: "SupportMembers",
                principalColumn: "SupportMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_SupportTypeSLAs_SupportTypeSLAId",
                table: "ServiceProviders",
                column: "SupportTypeSLAId",
                principalTable: "SupportTypeSLAs",
                principalColumn: "SupportTypeSlaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Customers_CustomerId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_ServiceProviders_ServiceProviderId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_Customers_CustomerId",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_Products_ProductId",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_SupportMembers_SupportMemberId",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_SupportTypeSLAs_SupportTypeSLAId",
                table: "ServiceProviders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SupportMembers");

            migrationBuilder.DropTable(
                name: "SupportTypeSLAs");

            migrationBuilder.DropTable(
                name: "LicencedProducts");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_CustomerId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_ProductId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_SupportMemberId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_SupportTypeSLAId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CustomerId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_ServiceProviderId",
                table: "Countries");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fadb219-a48b-4d5d-b81c-50a6f6323377");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1433052-b9b9-420c-befb-7e8bf8cea1a4");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "SupportMemberId",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "SupportTypeSLAId",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ServiceProviderId",
                table: "Countries");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_Countries_CountryId",
                table: "ServiceProviders",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
