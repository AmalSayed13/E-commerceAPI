using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerceAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Role", "SecurityStamp" },
                values: new object[] { "1104847b-1ac7-47d5-8fa8-f59cffcf1a66", 0, "a09f6699-6b8d-4a89-bfbb-47143493aacc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Role", "SecurityStamp" },
                values: new object[] { "7cdabab2-ac7c-4754-aca1-398530ba40e9", 0, "66cb07ea-c020-48b9-ab80-e2ae93039ebd" });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 13, 21, 26, 49, 428, DateTimeKind.Local).AddTicks(272));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 13, 21, 26, 49, 428, DateTimeKind.Local).AddTicks(338));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 13, 21, 26, 49, 428, DateTimeKind.Local).AddTicks(345));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 13, 21, 26, 49, 428, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 13, 21, 26, 49, 428, DateTimeKind.Local).AddTicks(407));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 13, 21, 26, 49, 428, DateTimeKind.Local).AddTicks(417));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8e3d5cb3-b261-4b10-9b72-743ae235acd4", "94018e97-6a74-42b5-b9a3-c08d013fb811" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "da648a0d-5531-41c7-8fa7-44607b505329", "fece897a-b24a-4a1e-a000-636cb9526a01" });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 23, 10, 3, 81, DateTimeKind.Local).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 23, 10, 3, 81, DateTimeKind.Local).AddTicks(2937));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 23, 10, 3, 81, DateTimeKind.Local).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 23, 10, 3, 81, DateTimeKind.Local).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 12, 23, 10, 3, 81, DateTimeKind.Local).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 12, 23, 10, 3, 81, DateTimeKind.Local).AddTicks(3042));
        }
    }
}
