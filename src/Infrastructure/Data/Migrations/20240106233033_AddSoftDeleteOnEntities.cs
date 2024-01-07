using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteOnEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingLines_Billings_BillingId_BillingCustomerId",
                table: "BillingLines");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Billings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "BillingCustomerId",
                table: "BillingLines",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingLines_Billings_BillingId_BillingCustomerId",
                table: "BillingLines",
                columns: new[] { "BillingId", "BillingCustomerId" },
                principalTable: "Billings",
                principalColumns: new[] { "Id", "CustomerId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingLines_Billings_BillingId_BillingCustomerId",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Billings");

            migrationBuilder.AlterColumn<Guid>(
                name: "BillingCustomerId",
                table: "BillingLines",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingLines_Billings_BillingId_BillingCustomerId",
                table: "BillingLines",
                columns: new[] { "BillingId", "BillingCustomerId" },
                principalTable: "Billings",
                principalColumns: new[] { "Id", "CustomerId" });
        }
    }
}
