using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class New1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Day",
                table: "WorkingHours",
                newName: "DayOfWeek");

            migrationBuilder.RenameColumn(
                name: "FreeTime",
                table: "Doctors",
                newName: "AppointmentInterval");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "AppointmentInterval",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "AppointmentInterval",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "AppointmentInterval",
                value: 20);

            migrationBuilder.InsertData(
                table: "WorkingHours",
                columns: new[] { "Id", "DayOfWeek", "DoctorId", "FromWorkHour", "ToWorkHour" },
                values: new object[,]
                {
                    { 1L, 0, 1L, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { 2L, 6, 2L, new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0) },
                    { 3L, 1, 3L, new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 20, 30, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "WorkingHours",
                newName: "Day");

            migrationBuilder.RenameColumn(
                name: "AppointmentInterval",
                table: "Doctors",
                newName: "FreeTime");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FreeTime",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "FreeTime",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FreeTime",
                value: 0);
        }
    }
}
