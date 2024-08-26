using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRestApi.Migrations
{
    /// <inheritdoc />
    public partial class checkedoutuserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_CheckedOut_UserId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CheckedOut_UserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CheckedOut_UserId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "ID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Books",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "CheckedOutUserIdId",
                table: "Books",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CheckedOutUserIdId",
                table: "Books",
                column: "CheckedOutUserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_CheckedOutUserIdId",
                table: "Books",
                column: "CheckedOutUserIdId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_CheckedOutUserIdId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CheckedOutUserIdId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CheckedOutUserIdId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Books",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckedOut_UserId",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CheckedOut_UserId",
                table: "Books",
                column: "CheckedOut_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_CheckedOut_UserId",
                table: "Books",
                column: "CheckedOut_UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
