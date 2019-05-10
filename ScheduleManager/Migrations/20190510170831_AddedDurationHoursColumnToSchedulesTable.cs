using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleManager.Migrations
{
    public partial class AddedDurationHoursColumnToSchedulesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DurationHours",
                table: "Schedules",
                nullable: false,
                defaultValue: 8f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationHours",
                table: "Schedules");
        }
    }
}
