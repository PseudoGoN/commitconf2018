using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PythonSucks.Data.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hater",
                columns: new[] { "Id", "ChildTrauma", "CreateDate", "Name", "Surname", "UpdateDate" },
                values: new object[] { new Guid("59a7731a-a094-4550-a62e-9782dbc05bd6"), "His bike was pink.", new DateTime(2018, 10, 23, 16, 29, 36, 551, DateTimeKind.Utc), "Gonzalo", "Rubio", new DateTime(2018, 10, 23, 16, 29, 36, 552, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Hater",
                columns: new[] { "Id", "ChildTrauma", "CreateDate", "Name", "Surname", "UpdateDate" },
                values: new object[] { new Guid("20edcdf4-91f2-439c-a825-27548e01e249"), "He saw his parents in bed.", new DateTime(2018, 10, 23, 16, 29, 36, 552, DateTimeKind.Utc), "Jorge", "Jardines", new DateTime(2018, 10, 23, 16, 29, 36, 552, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Reason",
                columns: new[] { "Id", "CreateDate", "Description", "HaterId", "HaterId1", "RageLevel", "Title", "UpdateDate" },
                values: new object[] { new Guid("59a7731a-a094-4550-a62e-9782dbc05bd6"), new DateTime(2018, 10, 23, 16, 29, 36, 579, DateTimeKind.Utc), "Python grammar is not as easy as people say.", new Guid("59a7731a-a094-4550-a62e-9782dbc05bd6"), null, 2, "Grammar", new DateTime(2018, 10, 23, 16, 29, 36, 579, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Reason",
                columns: new[] { "Id", "CreateDate", "Description", "HaterId", "HaterId1", "RageLevel", "Title", "UpdateDate" },
                values: new object[] { new Guid("bfb34ae9-5ae8-4926-b138-1865d047c3ec"), new DateTime(2018, 10, 23, 16, 29, 36, 579, DateTimeKind.Utc), "No interfaces! WTF!", new Guid("59a7731a-a094-4550-a62e-9782dbc05bd6"), null, 5, "Interfaces", new DateTime(2018, 10, 23, 16, 29, 36, 579, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hater",
                keyColumn: "Id",
                keyValue: new Guid("20edcdf4-91f2-439c-a825-27548e01e249"));

            migrationBuilder.DeleteData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: new Guid("59a7731a-a094-4550-a62e-9782dbc05bd6"));

            migrationBuilder.DeleteData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: new Guid("bfb34ae9-5ae8-4926-b138-1865d047c3ec"));

            migrationBuilder.DeleteData(
                table: "Hater",
                keyColumn: "Id",
                keyValue: new Guid("59a7731a-a094-4550-a62e-9782dbc05bd6"));
        }
    }
}
