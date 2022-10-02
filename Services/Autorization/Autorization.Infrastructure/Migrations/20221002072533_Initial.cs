using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authorization.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(36)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Surname = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Login = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    CreatedBy = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
