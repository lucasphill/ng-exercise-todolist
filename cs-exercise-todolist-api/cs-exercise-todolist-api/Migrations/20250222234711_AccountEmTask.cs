using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cs_exercise_todolist_api.Migrations
{
    /// <inheritdoc />
    public partial class AccountEmTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountID",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AccountModelId",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AccountModelId",
                table: "Tasks",
                column: "AccountModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_AccountModelId",
                table: "Tasks",
                column: "AccountModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AccountModelId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AccountModelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AccountModelId",
                table: "Tasks");
        }
    }
}
