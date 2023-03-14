using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flaskehalsen.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubPersonRels",
                table: "ClubPersonRels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClubPersonRels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubPersonRels",
                table: "ClubPersonRels",
                columns: new[] { "ClubId", "PersonId" });

            migrationBuilder.CreateTable(
                name: "ClubInvitation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvitationStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubInvitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubInvitation_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubInvitation_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GetTogethers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetTogethers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GetTogethers_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GetTogetherPersonRel",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GetTogetherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetTogetherPersonRel", x => new { x.GetTogetherId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_GetTogetherPersonRel_GetTogethers_GetTogetherId",
                        column: x => x.GetTogetherId,
                        principalTable: "GetTogethers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GetTogetherPersonRel_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubPersonRels_PersonId",
                table: "ClubPersonRels",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubInvitation_ClubId",
                table: "ClubInvitation",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubInvitation_PersonId",
                table: "ClubInvitation",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_GetTogetherPersonRel_PersonId",
                table: "GetTogetherPersonRel",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_GetTogethers_ClubId",
                table: "GetTogethers",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubPersonRels_Clubs_ClubId",
                table: "ClubPersonRels",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubPersonRels_Persons_PersonId",
                table: "ClubPersonRels",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubPersonRels_Clubs_ClubId",
                table: "ClubPersonRels");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubPersonRels_Persons_PersonId",
                table: "ClubPersonRels");

            migrationBuilder.DropTable(
                name: "ClubInvitation");

            migrationBuilder.DropTable(
                name: "GetTogetherPersonRel");

            migrationBuilder.DropTable(
                name: "GetTogethers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubPersonRels",
                table: "ClubPersonRels");

            migrationBuilder.DropIndex(
                name: "IX_ClubPersonRels_PersonId",
                table: "ClubPersonRels");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ClubPersonRels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubPersonRels",
                table: "ClubPersonRels",
                column: "Id");
        }
    }
}
