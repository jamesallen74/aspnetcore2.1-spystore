using Microsoft.EntityFrameworkCore.Migrations;

namespace SpyStore.Dal.EfStructures.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "OrderTotal",
                schema: "Store",
                table: "Orders",
                type: "money",
                nullable: false,
                computedColumnSql: "Store.GetOrderTotal([Id])",
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "LineItemTotal",
                schema: "Store",
                table: "OrderDetails",
                type: "money",
                nullable: false,
                computedColumnSql: "[Quantity]*[UnitCost]",
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "OrderTotal",
                schema: "Store",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldComputedColumnSql: "Store.GetOrderTotal([Id])");

            migrationBuilder.AlterColumn<decimal>(
                name: "LineItemTotal",
                schema: "Store",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldComputedColumnSql: "[Quantity]*[UnitCost]");
        }
    }
}
