using EWSoftware.PDI;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ScheduleManager.Migrations
{
    public partial class DerivedSchedulesTableFromEventClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationHours",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "RepeatAfterDays",
                table: "Schedules",
                newName: "Interval");

            migrationBuilder.AddColumn<bool>(
                name: "CanOccurOnHolidays",
                table: "Schedules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "Schedules",
                nullable: false,
                defaultValue: RecurFrequency.Weekly);

            migrationBuilder.AddColumn<bool>(
                name: "IsAllDay",
                table: "Schedules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Schedules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnWeekdays",
                table: "Schedules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecurUntil",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RepeatsIndefinitely",
                table: "Schedules",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanOccurOnHolidays",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "IsAllDay",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "IsOnWeekdays",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "RecurUntil",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "RepeatsIndefinitely",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "Interval",
                table: "Schedules",
                newName: "RepeatAfterDays");

            migrationBuilder.AddColumn<float>(
                name: "DurationHours",
                table: "Schedules",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
