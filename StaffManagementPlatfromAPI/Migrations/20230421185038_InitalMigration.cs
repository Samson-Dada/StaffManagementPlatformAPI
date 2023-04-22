using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagementPlatfromAPI.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "ricoli in informati la prieghi opomo", "IT & Software" },
                    { 2, "ricoli in informat", "Sales & Marketing" },
                    { 3, "Salary, finanace", "Account and Auditing" },
                    { 4, "Human Resources and Training", "Human Resources and Recruitment" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Address", "DateOfBirth", "DepartmentId", "DepartmentName", "Email", "FirstName", "HireDate", "LastName", "Phone", "Role", "Salary" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "IT & Software", "joh@mail.com", "Kemi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salem", "234 555 555", "Software Tester", 80001.3m },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "IT & Software", "brose@mail.com", "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seun", "234 555 555", "UI & UX Designer", 60000.3m },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "joh@mail.com", "John", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deo", "234 555 555", "Software Engineer", 0m },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sales & Marketing", "obieme@mail.com", "Obi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emefiele", "234 555 555", "Product and Digital Marketing", 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DepartmentId",
                table: "Staffs",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
