﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace English.Store.Migrations
{
    /// <inheritdoc />
    public partial class UserState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Users");
        }
    }
}
