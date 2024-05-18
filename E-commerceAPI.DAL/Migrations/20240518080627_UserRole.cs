using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerceAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserRole" },
                values: new object[] { "f9d46eca-0307-4ac7-828f-4fd918003e2d", "e896453a-386f-43af-9c02-73630d8060ae", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserRole" },
                values: new object[] { "306d6060-8409-49c9-a8e7-c4f7f23da2eb", "0075d3b6-78c8-4448-947e-1f26e5e55740", "Admin" });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 11, 6, 24, 746, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 11, 6, 24, 746, DateTimeKind.Local).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 11, 6, 24, 746, DateTimeKind.Local).AddTicks(5019));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 11, 6, 24, 746, DateTimeKind.Local).AddTicks(5023));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 18, 11, 6, 24, 746, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 18, 11, 6, 24, 746, DateTimeKind.Local).AddTicks(5072));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
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
    }
}
