using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flaskehalsen.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveScaleFromScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlaskScore_Scale_ScaleId",
                table: "FlaskScore");

            migrationBuilder.DropIndex(
                name: "IX_FlaskScore_ScaleId",
                table: "FlaskScore");

            migrationBuilder.DropColumn(
                name: "ScaleId",
                table: "FlaskScore");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ScaleId",
                table: "FlaskScore",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FlaskScore_ScaleId",
                table: "FlaskScore",
                column: "ScaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlaskScore_Scale_ScaleId",
                table: "FlaskScore",
                column: "ScaleId",
                principalTable: "Scale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
