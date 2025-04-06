using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facebook.Migrations
{
    /// <inheritdoc />
    public partial class CreateUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    BirthDate = table.Column<string>(type: "TEXT", nullable: false),
                    ProfilePic = table.Column<string>(type: "TEXT", nullable: false),
                    CoverPhoto = table.Column<string>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    MobileNumber = table.Column<int>(type: "INTEGER", maxLength: 20, nullable: false),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
