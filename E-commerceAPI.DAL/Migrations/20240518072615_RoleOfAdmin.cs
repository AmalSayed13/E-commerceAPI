using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerceAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RoleOfAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38df27b2-f191-4327-86ab-a5918a9a9ed6", "16c60b59-c629-480f-a0dc-4e370a70ea43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "27b762bc-72d7-4cd9-b932-9115d20c3064", "561bad49-ab7c-4704-bf6b-128ea638cd98" });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 10, 26, 12, 400, DateTimeKind.Local).AddTicks(8225));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 10, 26, 12, 400, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 10, 26, 12, 400, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 10, 26, 12, 400, DateTimeKind.Local).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 18, 10, 26, 12, 400, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 18, 10, 26, 12, 400, DateTimeKind.Local).AddTicks(8333));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
