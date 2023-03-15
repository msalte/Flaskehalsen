using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flaskehalsen.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ScaleId",
                table: "GetTogethers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Flask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(6,4)", precision: 6, scale: 4, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValueJsonArray = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GetTogetherFlasks",
                columns: table => new
                {
                    GetTogetherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetTogetherFlasks", x => new { x.FlaskId, x.GetTogetherId });
                    table.ForeignKey(
                        name: "FK_GetTogetherFlasks_Flask_FlaskId",
                        column: x => x.FlaskId,
                        principalTable: "Flask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GetTogetherFlasks_GetTogethers_GetTogetherId",
                        column: x => x.GetTogetherId,
                        principalTable: "GetTogethers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlaskScore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GetTogetherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScoreScaleIndex = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlaskScore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlaskScore_Flask_FlaskId",
                        column: x => x.FlaskId,
                        principalTable: "Flask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlaskScore_GetTogethers_GetTogetherId",
                        column: x => x.GetTogetherId,
                        principalTable: "GetTogethers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlaskScore_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlaskScore_Scale_ScaleId",
                        column: x => x.ScaleId,
                        principalTable: "Scale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GetTogethers_ScaleId",
                table: "GetTogethers",
                column: "ScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_FlaskScore_FlaskId",
                table: "FlaskScore",
                column: "FlaskId");

            migrationBuilder.CreateIndex(
                name: "IX_FlaskScore_GetTogetherId",
                table: "FlaskScore",
                column: "GetTogetherId");

            migrationBuilder.CreateIndex(
                name: "IX_FlaskScore_PersonId",
                table: "FlaskScore",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FlaskScore_ScaleId",
                table: "FlaskScore",
                column: "ScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_GetTogetherFlasks_GetTogetherId",
                table: "GetTogetherFlasks",
                column: "GetTogetherId");

            migrationBuilder.AddForeignKey(
                name: "FK_GetTogethers_Scale_ScaleId",
                table: "GetTogethers",
                column: "ScaleId",
                principalTable: "Scale",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetTogethers_Scale_ScaleId",
                table: "GetTogethers");

            migrationBuilder.DropTable(
                name: "FlaskScore");

            migrationBuilder.DropTable(
                name: "GetTogetherFlasks");

            migrationBuilder.DropTable(
                name: "Scale");

            migrationBuilder.DropTable(
                name: "Flask");

            migrationBuilder.DropIndex(
                name: "IX_GetTogethers_ScaleId",
                table: "GetTogethers");

            migrationBuilder.DropColumn(
                name: "ScaleId",
                table: "GetTogethers");
        }
    }
}
