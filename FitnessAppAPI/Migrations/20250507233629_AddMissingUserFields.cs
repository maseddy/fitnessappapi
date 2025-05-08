using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "CreatedAt", "CreatedBy", "Email", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "UpdateDate", "UpdatedBy", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), "system", "admin@fitness.com", "$2a$11$N9qo8uLOickgx2ZMRZoMy.MrE7r7ebsBqODTf2Yr6Pw3XoYjQbHIO", null, null, null, null, "admin" },
                    { 2, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), "system", "trainer@fitness.com", "$2a$11$N9qo8uLOickgx2ZMRZoMy.MrE7r7ebsBqODTf2Yr6Pw3XoYjQbHIO", null, null, null, null, "trainer1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
