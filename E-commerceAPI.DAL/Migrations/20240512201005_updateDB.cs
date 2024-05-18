using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerceAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "ID", "UserId" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" }
                });

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

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "ID", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 12, 23, 10, 3, 81, DateTimeKind.Local).AddTicks(2852), 66666m, 1, 1 },
                    { 2, 1, new DateTime(2024, 5, 12, 23, 10, 3, 81, DateTimeKind.Local).AddTicks(2937), 59750m, 2, 1 },
                    { 3, 2, new DateTime(2024, 5, 12, 23, 10, 3, 81, DateTimeKind.Local).AddTicks(2945), 66666m, 1, 1 },
                    { 4, 2, new DateTime(2024, 5, 12, 23, 10, 3, 81, DateTimeKind.Local).AddTicks(2951), 59750m, 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "83cb18ce-46bd-49dd-8911-d84231000d29", "c5c646fb-9fe1-4b9d-82e6-cba173629c13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b0e16934-709b-42a6-a763-3ce7f63dec72", "84ce1a31-7a98-4222-8a70-e000c64a4246" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 12, 22, 48, 36, 712, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 12, 22, 48, 36, 712, DateTimeKind.Local).AddTicks(9333));
        }
    }
}
