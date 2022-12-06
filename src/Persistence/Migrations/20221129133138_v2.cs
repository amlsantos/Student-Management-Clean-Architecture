using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Credits", "Name" },
                values: new object[,]
                {
                    { new Guid("13b7c797-1cf4-4dc4-9328-b945a8cea5bd"), 13, "Science" },
                    { new Guid("1ec42a3c-9fb8-4148-b6ec-93a235ce6493"), 15, "Math" },
                    { new Guid("238105e8-973d-4068-8c0e-e7fd7df6bab5"), 13, "English" },
                    { new Guid("8f1e73b4-3935-4b4f-946f-99bdcfec946a"), 12, "Politics" },
                    { new Guid("e21c1f02-3086-44b6-a247-81bfc65eda36"), 9, "Philosophy" },
                    { new Guid("f4515227-a87c-479e-b095-2806b568834a"), 15, "Portuguese" },
                    { new Guid("ff5ca171-cf9f-4388-8e58-ca7a82bed01e"), 10, "Sport" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("07ff3eda-b1ad-4227-8ac2-7154cb88e64b"), "student2@email.com", "student 2" },
                    { new Guid("3fbccb11-f961-44fa-ba3f-8e208532cda0"), "student1@email.com", "student 1" },
                    { new Guid("49f8552a-12a9-4f0b-a872-a8aa31893089"), "student3@email.com", "student 3" },
                    { new Guid("dc8d125f-ae1a-4bc5-9068-f0ab152fc53f"), "student4@email.com", "student 4" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("256c64bb-fc23-4428-a391-87c111d931c8"), new Guid("1ec42a3c-9fb8-4148-b6ec-93a235ce6493"), 0, new Guid("dc8d125f-ae1a-4bc5-9068-f0ab152fc53f") },
                    { new Guid("33933691-6fc3-413e-bacd-a73429501b02"), new Guid("1ec42a3c-9fb8-4148-b6ec-93a235ce6493"), 0, new Guid("49f8552a-12a9-4f0b-a872-a8aa31893089") },
                    { new Guid("5af46425-d948-443b-a1fd-3fd063e0797a"), new Guid("1ec42a3c-9fb8-4148-b6ec-93a235ce6493"), 0, new Guid("07ff3eda-b1ad-4227-8ac2-7154cb88e64b") },
                    { new Guid("5f382af3-ed3e-4eb8-977f-3eabd6f8fb45"), new Guid("f4515227-a87c-479e-b095-2806b568834a"), 0, new Guid("dc8d125f-ae1a-4bc5-9068-f0ab152fc53f") },
                    { new Guid("9993a8ca-46f4-4209-95c3-eaebe5053b27"), new Guid("f4515227-a87c-479e-b095-2806b568834a"), 0, new Guid("07ff3eda-b1ad-4227-8ac2-7154cb88e64b") },
                    { new Guid("b2750a61-a3fe-4c11-bc24-4db15f2bdd48"), new Guid("f4515227-a87c-479e-b095-2806b568834a"), 0, new Guid("49f8552a-12a9-4f0b-a872-a8aa31893089") },
                    { new Guid("b6f6f081-454e-4e6f-92bf-e7ed5cee5efd"), new Guid("f4515227-a87c-479e-b095-2806b568834a"), 0, new Guid("3fbccb11-f961-44fa-ba3f-8e208532cda0") },
                    { new Guid("fcfe2236-1655-45a2-a867-4029647cca27"), new Guid("1ec42a3c-9fb8-4148-b6ec-93a235ce6493"), 0, new Guid("3fbccb11-f961-44fa-ba3f-8e208532cda0") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("13b7c797-1cf4-4dc4-9328-b945a8cea5bd"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("238105e8-973d-4068-8c0e-e7fd7df6bab5"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("8f1e73b4-3935-4b4f-946f-99bdcfec946a"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("e21c1f02-3086-44b6-a247-81bfc65eda36"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("ff5ca171-cf9f-4388-8e58-ca7a82bed01e"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("256c64bb-fc23-4428-a391-87c111d931c8"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("33933691-6fc3-413e-bacd-a73429501b02"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("5af46425-d948-443b-a1fd-3fd063e0797a"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("5f382af3-ed3e-4eb8-977f-3eabd6f8fb45"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("9993a8ca-46f4-4209-95c3-eaebe5053b27"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("b2750a61-a3fe-4c11-bc24-4db15f2bdd48"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("b6f6f081-454e-4e6f-92bf-e7ed5cee5efd"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("fcfe2236-1655-45a2-a867-4029647cca27"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("1ec42a3c-9fb8-4148-b6ec-93a235ce6493"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f4515227-a87c-479e-b095-2806b568834a"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("07ff3eda-b1ad-4227-8ac2-7154cb88e64b"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("3fbccb11-f961-44fa-ba3f-8e208532cda0"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("49f8552a-12a9-4f0b-a872-a8aa31893089"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("dc8d125f-ae1a-4bc5-9068-f0ab152fc53f"));
        }
    }
}
