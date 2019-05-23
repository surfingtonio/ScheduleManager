using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleManager.Migrations
{
    public partial class CreatedMasterSchedulesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterScheduleId",
                table: "DaysOfWeek",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MasterSchedules",
                columns: table => new
                {
                    MasterScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    DurationHours = table.Column<int>(nullable: false),
                    Frequency = table.Column<int>(nullable: false),
                    Interval = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsAllDay = table.Column<bool>(nullable: false),
                    IsOnWeekdays = table.Column<bool>(nullable: false),
                    CanOccurOnHolidays = table.Column<bool>(nullable: false),
                    RepeatsIndefinitely = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSchedules", x => x.MasterScheduleId);
                    table.ForeignKey(
                        name: "FK_MasterSchedules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaysOfWeek_MasterScheduleId",
                table: "DaysOfWeek",
                column: "MasterScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSchedules_EmployeeId",
                table: "MasterSchedules",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DaysOfWeek_MasterSchedules_MasterScheduleId",
                table: "DaysOfWeek",
                column: "MasterScheduleId",
                principalTable: "MasterSchedules",
                principalColumn: "MasterScheduleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysOfWeek_MasterSchedules_MasterScheduleId",
                table: "DaysOfWeek");

            migrationBuilder.DropTable(
                name: "MasterSchedules");

            migrationBuilder.DropIndex(
                name: "IX_DaysOfWeek_MasterScheduleId",
                table: "DaysOfWeek");

            migrationBuilder.DropColumn(
                name: "MasterScheduleId",
                table: "DaysOfWeek");
        }
    }
}
