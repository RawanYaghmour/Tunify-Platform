using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedRolsAndAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" },
                    { "user", "00000000-0000-0000-0000-000000000000", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin_user_id", 0, "24fdf763-cdbb-4e29-9d68-662d003741af", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEN2q8kzFHi/pYouW57aFhz4t/j4RzRirg9JWl0FNsyu6Ux42Gm5eMtJ3M0mIsBO9XA==", null, false, "14c6adf9-0418-44bc-a3d8-f1fa026cafb4", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -1123665763, "permission", "update", "user" },
                    { -628583739, "permission", "update", "admin" },
                    { 39280849, "permission", "delete", "admin" },
                    { 696073484, "permission", "create", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1379146256, "permission", "full_access", "admin_user_id" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "admin", "admin_user_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1123665763);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -628583739);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 39280849);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 696073484);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1379146256);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin", "admin_user_id" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin_user_id");
        }
    }
}
