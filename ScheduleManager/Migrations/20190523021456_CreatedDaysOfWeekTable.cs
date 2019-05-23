using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleManager.Migrations
{
    public partial class CreatedDaysOfWeekTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaysOfWeek",
                columns: table => new
                {
                    DayOfWeekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOfWeek", x => x.DayOfWeekId);
                });

            migrationBuilder.InsertData(
                table: "DaysOfWeek",
                columns: new[] { "DayOfWeekId", "Name" },
                values: new object[] { 0, "Sunday" }
            );

            migrationBuilder.InsertData(
                table: "DaysOfWeek",
                columns: new[] { "DayOfWeekId", "Name" },
                values: new object[] { 1, "Monday" }
            );

            migrationBuilder.InsertData(
                table: "DaysOfWeek",
                columns: new[] { "DayOfWeekId", "Name" },
                values: new object[] { 2, "Tuesday" }
            );

            migrationBuilder.InsertData(
                table: "DaysOfWeek",
                columns: new[] { "DayOfWeekId", "Name" },
                values: new object[] { 3, "Wednesday" }
            );

            migrationBuilder.InsertData(
                table: "DaysOfWeek",
                columns: new[] { "DayOfWeekId", "Name" },
                values: new object[] { 4, "Thursday" }
            );

            migrationBuilder.InsertData(
                table: "DaysOfWeek",
                columns: new[] { "DayOfWeekId", "Name" },
                values: new object[] { 5, "Friday" }
            );

            migrationBuilder.InsertData(
                table: "DaysOfWeek",
                columns: new[] { "DayOfWeekId", "Name" },
                values: new object[] { 6, "Saturday" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaysOfWeek");
        }
    }
}
