using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbeitszeitaufzeichnung.Migrations
{
    public partial class WorkTimesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Worktimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Come = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Go = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinimumBreak = table.Column<byte>(type: "tinyint", nullable: false),
                    LongestBreak = table.Column<short>(type: "smallint", nullable: false),
                    WorkTime = table.Column<short>(type: "smallint", nullable: false),
                    TotalBreakTime = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worktimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worktimes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Worktimes_EmployeeId",
                table: "Worktimes",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Worktimes");
        }
    }
}
