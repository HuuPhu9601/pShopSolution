    using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 23, 8, 6, 12, 549, DateTimeKind.Local).AddTicks(6743),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 2, 22, 10, 9, 31, 559, DateTimeKind.Local).AddTicks(8658));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 22, 10, 9, 31, 559, DateTimeKind.Local).AddTicks(8658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 2, 23, 8, 6, 12, 549, DateTimeKind.Local).AddTicks(6743));
        }
    }
}
