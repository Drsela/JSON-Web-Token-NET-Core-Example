using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JwtIssueExample.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Type", "UserName" },
                values: new object[] { new Guid("54d39f1a-ef2d-4816-b2e8-90991f548bf0"), "RegularPassword", 1, "Regular" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Type", "UserName" },
                values: new object[] { new Guid("36f72591-1d95-4e4f-877c-261d3386df94"), "AdminPassword", 2, "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Type", "UserName" },
                values: new object[] { new Guid("fb270c9a-9479-4bd0-9c86-589f3fa84527"), "SuperPassword", 3, "Super" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
