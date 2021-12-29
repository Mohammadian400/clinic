using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Expertise", "Family", "JobAddress", "Name", "Phone" },
                values: new object[,]
                {
                    { 1L, "قلب", "محسنی", "address1", "علی", "0912457589" },
                    { 2L, "پوست", "امامی", "address2", "پویا", "0912358974" },
                    { 3L, "داخلی", "نادری", "address3", "اکرم", "0912763548" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Family", "Image", "Name", "NationalCode", "Password", "RegisterDate", "UserName" },
                values: new object[,]
                {
                    { 1, "محسنی", null, "رضا", "0014725821", "0912457589", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "علی" },
                    { 2, "امامی", null, "پوریا", "0032165498", "0912457589", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "پویا" },
                    { 3, "نادری", null, "مینا", "0085296345", "0912457589", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اکرم" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
