using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AQC.Manifestly.Core.Domain.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AQC.Manifestly");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "AQC.Manifestly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "AQC.Manifestly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SimpleDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflow",
                schema: "AQC.Manifestly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflow_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "AQC.Manifestly",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Run",
                schema: "AQC.Manifestly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailedTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentCompleted = table.Column<double>(type: "float", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArchiveUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkflowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Run", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Run_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalSchema: "AQC.Manifestly",
                        principalTable: "Workflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RunStep",
                schema: "AQC.Manifestly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RunId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skipped = table.Column<bool>(type: "bit", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunStep_Run_RunId",
                        column: x => x.RunId,
                        principalSchema: "AQC.Manifestly",
                        principalTable: "Run",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RunStep_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "AQC.Manifestly",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RunStepComment",
                schema: "AQC.Manifestly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentWithLinks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RunStepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunStepComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunStepComment_RunStep_RunStepId",
                        column: x => x.RunStepId,
                        principalSchema: "AQC.Manifestly",
                        principalTable: "RunStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Run_WorkflowId",
                schema: "AQC.Manifestly",
                table: "Run",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_RunStep_RunId",
                schema: "AQC.Manifestly",
                table: "RunStep",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_RunStep_UserId",
                schema: "AQC.Manifestly",
                table: "RunStep",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RunStepComment_RunStepId",
                schema: "AQC.Manifestly",
                table: "RunStepComment",
                column: "RunStepId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_DepartmentId",
                schema: "AQC.Manifestly",
                table: "Workflow",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunStepComment",
                schema: "AQC.Manifestly");

            migrationBuilder.DropTable(
                name: "RunStep",
                schema: "AQC.Manifestly");

            migrationBuilder.DropTable(
                name: "Run",
                schema: "AQC.Manifestly");

            migrationBuilder.DropTable(
                name: "User",
                schema: "AQC.Manifestly");

            migrationBuilder.DropTable(
                name: "Workflow",
                schema: "AQC.Manifestly");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "AQC.Manifestly");
        }
    }
}
