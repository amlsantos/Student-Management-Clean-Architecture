using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("24816d8d-ba43-4eb1-8430-7434bcf03380"), 12, "Politics" },
                    { new Guid("38094811-dc2c-4572-a544-70e6d93376a3"), 13, "Science" },
                    { new Guid("680508d2-e5cc-438e-b3a6-027604c81a9b"), 15, "Math" },
                    { new Guid("7b144848-d7be-4be1-a320-66a9b71e1b97"), 15, "Portuguese" },
                    { new Guid("bedc2129-5ae8-4a2d-aa6a-9e7be7b8825c"), 10, "Sport" },
                    { new Guid("c978ea3e-7583-41ba-b04a-b9257aea2731"), 9, "Philosophy" },
                    { new Guid("d2f80086-3bc5-493a-ba62-4a561c8cfd2f"), 13, "English" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("3231ff4b-3aca-4896-971a-1163b27ed277"), "student4@email.com", "student 4" },
                    { new Guid("44009547-fc6c-4702-b044-0786cd3e70b8"), "student3@email.com", "student 3" },
                    { new Guid("537874a4-990d-4e06-878a-cc462c3aac14"), "student2@email.com", "student 2" },
                    { new Guid("f57cfdc7-7f1a-43d2-a69c-e6ae77c56d90"), "student1@email.com", "student 1" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("2ff82a0b-f67a-48bb-bc14-3a9c1c2ab56b"), new Guid("680508d2-e5cc-438e-b3a6-027604c81a9b"), 1, new Guid("f57cfdc7-7f1a-43d2-a69c-e6ae77c56d90") },
                    { new Guid("3cbcbcc1-573d-4bc5-a565-d47bf2b982d4"), new Guid("7b144848-d7be-4be1-a320-66a9b71e1b97"), 3, new Guid("537874a4-990d-4e06-878a-cc462c3aac14") },
                    { new Guid("653997ca-b240-489c-adcd-0dc529b62752"), new Guid("7b144848-d7be-4be1-a320-66a9b71e1b97"), 4, new Guid("3231ff4b-3aca-4896-971a-1163b27ed277") },
                    { new Guid("959c6725-0801-49fc-986a-80d7a6240466"), new Guid("680508d2-e5cc-438e-b3a6-027604c81a9b"), 4, new Guid("3231ff4b-3aca-4896-971a-1163b27ed277") },
                    { new Guid("a8360959-6cd9-46e5-b738-f886755ac24b"), new Guid("7b144848-d7be-4be1-a320-66a9b71e1b97"), 1, new Guid("44009547-fc6c-4702-b044-0786cd3e70b8") },
                    { new Guid("b9b811c7-d27a-44b0-b0ff-56fc3bbb29e1"), new Guid("7b144848-d7be-4be1-a320-66a9b71e1b97"), 2, new Guid("f57cfdc7-7f1a-43d2-a69c-e6ae77c56d90") },
                    { new Guid("c6c05962-cbb0-4e8f-b810-005f968a9280"), new Guid("680508d2-e5cc-438e-b3a6-027604c81a9b"), 1, new Guid("44009547-fc6c-4702-b044-0786cd3e70b8") },
                    { new Guid("de174bac-1b14-4ff2-8dba-13571ea53971"), new Guid("680508d2-e5cc-438e-b3a6-027604c81a9b"), 2, new Guid("537874a4-990d-4e06-878a-cc462c3aac14") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("24816d8d-ba43-4eb1-8430-7434bcf03380"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("38094811-dc2c-4572-a544-70e6d93376a3"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("bedc2129-5ae8-4a2d-aa6a-9e7be7b8825c"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("c978ea3e-7583-41ba-b04a-b9257aea2731"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d2f80086-3bc5-493a-ba62-4a561c8cfd2f"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("2ff82a0b-f67a-48bb-bc14-3a9c1c2ab56b"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("3cbcbcc1-573d-4bc5-a565-d47bf2b982d4"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("653997ca-b240-489c-adcd-0dc529b62752"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("959c6725-0801-49fc-986a-80d7a6240466"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("a8360959-6cd9-46e5-b738-f886755ac24b"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("b9b811c7-d27a-44b0-b0ff-56fc3bbb29e1"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("c6c05962-cbb0-4e8f-b810-005f968a9280"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("de174bac-1b14-4ff2-8dba-13571ea53971"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("680508d2-e5cc-438e-b3a6-027604c81a9b"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("7b144848-d7be-4be1-a320-66a9b71e1b97"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("3231ff4b-3aca-4896-971a-1163b27ed277"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("44009547-fc6c-4702-b044-0786cd3e70b8"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("537874a4-990d-4e06-878a-cc462c3aac14"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f57cfdc7-7f1a-43d2-a69c-e6ae77c56d90"));

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
    }
}
