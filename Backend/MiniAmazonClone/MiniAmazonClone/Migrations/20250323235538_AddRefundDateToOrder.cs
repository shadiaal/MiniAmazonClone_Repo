using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniAmazonClone.Migrations
{
    /// <inheritdoc />
    public partial class AddRefundDateToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefundDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1,
                columns: new[] { "OrderDate", "RefundDate" },
                values: new object[] { new DateTime(2025, 3, 24, 2, 55, 38, 740, DateTimeKind.Local).AddTicks(5039), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2,
                columns: new[] { "OrderDate", "RefundDate" },
                values: new object[] { new DateTime(2025, 3, 24, 2, 55, 38, 740, DateTimeKind.Local).AddTicks(5049), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3,
                columns: new[] { "OrderDate", "RefundDate" },
                values: new object[] { new DateTime(2025, 3, 24, 2, 55, 38, 740, DateTimeKind.Local).AddTicks(5052), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4,
                columns: new[] { "OrderDate", "RefundDate" },
                values: new object[] { new DateTime(2025, 3, 24, 2, 55, 38, 740, DateTimeKind.Local).AddTicks(5053), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 5,
                columns: new[] { "OrderDate", "RefundDate" },
                values: new object[] { new DateTime(2025, 3, 24, 2, 55, 38, 740, DateTimeKind.Local).AddTicks(5055), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefundDate",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9294));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9296));
        }
    }
}
