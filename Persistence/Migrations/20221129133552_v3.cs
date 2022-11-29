using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Credits", "Name" },
                values: new object[,]
                {
                    { new Guid("029f74d2-4fbe-4ddf-83bb-a40a77c955ba"), 10, "Sport" },
                    { new Guid("188f9120-bc51-4530-a3bd-00b735e3ab29"), 13, "English" },
                    { new Guid("2877cf21-45d6-47ad-901d-917b584f4dc8"), 15, "Portuguese" },
                    { new Guid("37de63d6-11a7-4087-b94e-6cad79940a01"), 15, "Math" },
                    { new Guid("5f03ad07-451f-41ce-9d4b-60aca4b8b655"), 12, "Politics" },
                    { new Guid("6b7e4bc0-f86e-4a24-8873-b597dcd795fd"), 13, "Science" },
                    { new Guid("d56090d8-45ca-4b2a-8fb4-0577b071c512"), 9, "Philosophy" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("66474f33-77bc-4ee2-b23e-8ecc8ba907a1"), "student4@email.com", "student 4" },
                    { new Guid("8f55d259-2d55-4aef-9c65-3c93f905e932"), "student2@email.com", "student 2" },
                    { new Guid("a055b09a-1d0f-4a2d-8626-a5ad51ce685e"), "student1@email.com", "student 1" },
                    { new Guid("cfd3b928-5fb8-46a7-b453-7e4e878f16e3"), "student3@email.com", "student 3" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("1bf274b6-02b0-4c60-bde7-179f280f37f4"), new Guid("2877cf21-45d6-47ad-901d-917b584f4dc8"), 4, new Guid("66474f33-77bc-4ee2-b23e-8ecc8ba907a1") },
                    { new Guid("2d7f26b8-b1d3-467a-bf23-5bb9919ea110"), new Guid("37de63d6-11a7-4087-b94e-6cad79940a01"), 0, new Guid("cfd3b928-5fb8-46a7-b453-7e4e878f16e3") },
                    { new Guid("4c2d45d5-aaa9-4b36-a2fa-95d85d65d62d"), new Guid("2877cf21-45d6-47ad-901d-917b584f4dc8"), 1, new Guid("cfd3b928-5fb8-46a7-b453-7e4e878f16e3") },
                    { new Guid("5a560340-392e-4eb6-9151-f70301ff34c1"), new Guid("2877cf21-45d6-47ad-901d-917b584f4dc8"), 2, new Guid("a055b09a-1d0f-4a2d-8626-a5ad51ce685e") },
                    { new Guid("bbf19f2d-bcd6-40b3-b5d4-5da009b3036e"), new Guid("37de63d6-11a7-4087-b94e-6cad79940a01"), 4, new Guid("66474f33-77bc-4ee2-b23e-8ecc8ba907a1") },
                    { new Guid("d15ed3a0-3737-4de7-a491-18c23c57003e"), new Guid("2877cf21-45d6-47ad-901d-917b584f4dc8"), 3, new Guid("8f55d259-2d55-4aef-9c65-3c93f905e932") },
                    { new Guid("db0d4bc3-45e2-4b3f-b457-086adf9c7fa1"), new Guid("37de63d6-11a7-4087-b94e-6cad79940a01"), 2, new Guid("8f55d259-2d55-4aef-9c65-3c93f905e932") },
                    { new Guid("e38b49de-7909-4e99-864b-d4d8ce5f858a"), new Guid("37de63d6-11a7-4087-b94e-6cad79940a01"), 1, new Guid("a055b09a-1d0f-4a2d-8626-a5ad51ce685e") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("029f74d2-4fbe-4ddf-83bb-a40a77c955ba"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("188f9120-bc51-4530-a3bd-00b735e3ab29"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("5f03ad07-451f-41ce-9d4b-60aca4b8b655"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6b7e4bc0-f86e-4a24-8873-b597dcd795fd"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d56090d8-45ca-4b2a-8fb4-0577b071c512"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("1bf274b6-02b0-4c60-bde7-179f280f37f4"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("2d7f26b8-b1d3-467a-bf23-5bb9919ea110"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("4c2d45d5-aaa9-4b36-a2fa-95d85d65d62d"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("5a560340-392e-4eb6-9151-f70301ff34c1"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("bbf19f2d-bcd6-40b3-b5d4-5da009b3036e"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("d15ed3a0-3737-4de7-a491-18c23c57003e"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("db0d4bc3-45e2-4b3f-b457-086adf9c7fa1"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("e38b49de-7909-4e99-864b-d4d8ce5f858a"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("2877cf21-45d6-47ad-901d-917b584f4dc8"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("37de63d6-11a7-4087-b94e-6cad79940a01"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("66474f33-77bc-4ee2-b23e-8ecc8ba907a1"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("8f55d259-2d55-4aef-9c65-3c93f905e932"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("a055b09a-1d0f-4a2d-8626-a5ad51ce685e"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("cfd3b928-5fb8-46a7-b453-7e4e878f16e3"));

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
    }
}
