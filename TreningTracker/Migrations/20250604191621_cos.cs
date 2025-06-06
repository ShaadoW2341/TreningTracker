using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TreningTracker.Migrations
{
    /// <inheritdoc />
    public partial class cos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoalSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DailyStepsGoal = table.Column<int>(type: "integer", nullable: false),
                    WeeklyTrainingsGoal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Calories = table.Column<int>(type: "integer", nullable: false),
                    Steps = table.Column<int>(type: "integer", nullable: false),
                    ActivityTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingSessions_ActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSessionTags",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "integer", nullable: false),
                    TrainingSessionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSessionTags", x => new { x.TagsId, x.TrainingSessionsId });
                    table.ForeignKey(
                        name: "FK_TrainingSessionTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingSessionTags_TrainingSessions_TrainingSessionsId",
                        column: x => x.TrainingSessionsId,
                        principalTable: "TrainingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bieganie" },
                    { 2, "Rower" },
                    { 3, "Spacer" },
                    { 4, "Siłownia" }
                });

            migrationBuilder.InsertData(
                table: "GoalSettings",
                columns: new[] { "Id", "DailyStepsGoal", "WeeklyTrainingsGoal" },
                values: new object[] { 1, 10000, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessions_ActivityTypeId",
                table: "TrainingSessions",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessionTags_TrainingSessionsId",
                table: "TrainingSessionTags",
                column: "TrainingSessionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoalSettings");

            migrationBuilder.DropTable(
                name: "TrainingSessionTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TrainingSessions");

            migrationBuilder.DropTable(
                name: "ActivityTypes");
        }
    }
}
