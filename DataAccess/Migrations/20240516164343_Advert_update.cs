﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Advert_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_AspNetUsers_UserAdminId",
                table: "Adverts");

            migrationBuilder.AlterColumn<string>(
                name: "UserAdminId",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_AspNetUsers_UserAdminId",
                table: "Adverts",
                column: "UserAdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_AspNetUsers_UserAdminId",
                table: "Adverts");

            migrationBuilder.AlterColumn<string>(
                name: "UserAdminId",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_AspNetUsers_UserAdminId",
                table: "Adverts",
                column: "UserAdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
