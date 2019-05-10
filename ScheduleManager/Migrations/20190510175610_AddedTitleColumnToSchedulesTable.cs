using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleManager.Migrations
{
    public partial class AddedTitleColumnToSchedulesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Schedules",
                nullable: false,
                defaultValue: "Schedule Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Schedules");
        }
    }
}
