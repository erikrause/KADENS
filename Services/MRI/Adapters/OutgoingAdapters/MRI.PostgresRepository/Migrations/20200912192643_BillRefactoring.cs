using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MRI.PostgresRepository.Migrations
{
    public partial class BillRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Bill_BillId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_BillId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "BLK",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "BillDate",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Payment");

            migrationBuilder.AddColumn<string>(
                name: "BIK",
                table: "Payment",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Bill",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "BillNumber",
                table: "Bill",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Payment_Id",
                table: "Bill",
                column: "Id",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Payment_Id",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "BIK",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "BillNumber",
                table: "Bill");

            migrationBuilder.AddColumn<string>(
                name: "BLK",
                table: "Payment",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BillDate",
                table: "Payment",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Payment",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Bill",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BillId",
                table: "Payment",
                column: "BillId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Bill_BillId",
                table: "Payment",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
