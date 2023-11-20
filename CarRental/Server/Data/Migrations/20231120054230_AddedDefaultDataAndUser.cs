using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRental.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "742306f4-af65-4ccf-a6ef-57287059ce75", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEKb8uEwfuBnUU4wFsBL1nEmFKETYlahsYRwYcF6yPSdkNZz/fRyjPPx6zjMiUVKLOQ==", null, false, "980498b8-a351-475e-a974-f6eb5963c40a", false, "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(3465), new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(3481) });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(3486), new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(3487) });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4126), new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4128), "BMW", "System" },
                    { 2, "System", new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4131), new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4132), "Toyota", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4704), new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4706), "3 Series", "System" },
                    { 2, "System", new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4709), new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4710), "X5", "System" },
                    { 3, "System", new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4712), new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4714), "Prius", "System" },
                    { 4, "System", new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4772), new DateTime(2023, 11, 20, 13, 42, 30, 217, DateTimeKind.Local).AddTicks(4773), "Rav4", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 20, 12, 46, 42, 143, DateTimeKind.Local).AddTicks(9000), new DateTime(2023, 11, 20, 12, 46, 42, 143, DateTimeKind.Local).AddTicks(9052) });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 20, 12, 46, 42, 143, DateTimeKind.Local).AddTicks(9061), new DateTime(2023, 11, 20, 12, 46, 42, 143, DateTimeKind.Local).AddTicks(9062) });
        }
    }
}
