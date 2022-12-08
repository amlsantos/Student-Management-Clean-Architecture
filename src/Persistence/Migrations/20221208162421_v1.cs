using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Credits = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disenrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disenrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disenrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disenrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Credits", "Name" },
                values: new object[,]
                {
                    { new Guid("0e882e0e-06dc-49a7-ada0-869674c9b5ab"), 5, "Electrical and Electronics Engineering" },
                    { new Guid("0e9fe44d-185c-4dc9-aba9-208de7d36cfe"), 21, "Electrical and Electronics Engineering" },
                    { new Guid("0f650700-8954-4d40-a463-965ac4a2af5f"), 23, "Construction Engineering" },
                    { new Guid("1674c76c-ac10-46bf-955d-0f9309f7177c"), 6, "Aeronautical Engineering" },
                    { new Guid("1aa44c1b-d9db-4050-a55d-04a625c1c24c"), 24, "Chemical Engineering" },
                    { new Guid("21166334-aca5-4b50-ad64-d0880a6d9ee3"), 11, "BTTM- Bachelor of Travel and Tourism Management" },
                    { new Guid("29335e30-c60c-4c8b-8310-3f4f41fb92e7"), 21, "Textile Engineering" },
                    { new Guid("302981e8-4922-4bcb-8695-9304d754a2dc"), 16, "BTTM- Bachelor of Travel and Tourism Management" },
                    { new Guid("3a770f67-66a7-45d9-8923-db4e81bd1663"), 11, "B.Sc- Interior Design" },
                    { new Guid("48517df9-b7ad-4831-a7c2-e3e632207eda"), 7, "Robotics Engineering" },
                    { new Guid("48719fec-da6e-4132-a2e2-e55a295f666d"), 25, "Civil Engineering" },
                    { new Guid("4c7a9083-5000-4739-8f6d-d94a90524173"), 23, "Automation and Robotics" },
                    { new Guid("4e09a068-d7db-4451-aff8-bb0c4706a55b"), 23, "BMS- Bachelor of Management Science" },
                    { new Guid("4eb78ab4-3578-4e72-b83e-643d9fc5f010"), 11, "Electronics and Communication Engineering" },
                    { new Guid("57f07cc7-2861-449d-975a-0993c1646693"), 28, "BFA- Bachelor of Fine Arts" },
                    { new Guid("5bd560d4-fd65-4d8b-a29b-e78710d28e27"), 19, "Biotechnology Engineering" },
                    { new Guid("5de57509-18e6-4a26-a0b9-02b49a0b736c"), 8, "Civil Engineering" },
                    { new Guid("5ea497be-a068-4263-bfc4-c6914fe82262"), 1, "BFD- Bachelor of Fashion Designing" },
                    { new Guid("6a25e83a-1356-429c-9aea-d30fb0b9dece"), 11, "BSW- Bachelor of Social Work" },
                    { new Guid("70de1eb7-991a-4583-b3da-b6f29300045c"), 5, "Structural Engineering" },
                    { new Guid("74b14e45-1e6e-4b86-9ed4-1e9f6e82dde4"), 7, "BFD- Bachelor of Fashion Designing" },
                    { new Guid("8572ef17-1801-4c46-976c-7bdd72686b22"), 8, "Petroleum Engineering" },
                    { new Guid("89a7cfc9-c176-4c0c-897a-85a72af27328"), 22, "Integrated Law Course- BA + LL.B" },
                    { new Guid("97554ca0-1a4c-43b8-a2b6-f8f5f5948aad"), 15, "Transportation Engineering" },
                    { new Guid("97e6e2a2-c6c9-4a98-80ac-cd1c8652dade"), 6, "Construction Engineering" },
                    { new Guid("9a6187c0-95a6-40ca-aaa9-ac2d91a7fd65"), 17, "Ceramic Engineering" },
                    { new Guid("a5103dba-56db-421f-867d-b50d78b217eb"), 6, "Instrumentation Engineering" },
                    { new Guid("a7402094-4232-42b3-9022-43b49cf537d2"), 18, "Biotechnology Engineering" },
                    { new Guid("a9123ad1-a12d-4cb5-976b-8791b693d938"), 26, "Computer Science and Engineering" },
                    { new Guid("b213e3e5-42b1-4715-8b87-18b0da21d8a5"), 8, "BBA- Bachelor of Business Administration" },
                    { new Guid("b44b6646-9828-471f-8f4b-31775857f812"), 1, "Instrumentation Engineering" },
                    { new Guid("b9aa3a2c-36b8-4ab7-91e5-afdf1c901e1c"), 9, "Bachelor of Performing Arts" },
                    { new Guid("c894d5b4-962b-4832-91dd-6c8250e35839"), 24, "Construction Engineering" },
                    { new Guid("c986bce5-2f09-419c-829e-2125a44bc222"), 28, "Smart Manufacturing & Automation" },
                    { new Guid("cf65b6dc-99b3-4148-95da-ba5f675769b6"), 20, "Bachelor of Performing Arts" },
                    { new Guid("d3bc773b-97a9-4078-897c-decfd6bfffc6"), 15, "Electronics and Communication Engineering" },
                    { new Guid("dc5dfd82-7ce4-4b3a-ad36-4ff9a47ba5c3"), 12, "Aviation Courses" },
                    { new Guid("e29a950e-3d26-4e41-8dce-7d80df4f881e"), 0, "Robotics Engineering" },
                    { new Guid("eef738ff-7d6c-4d91-ac1b-71948ba0f351"), 17, "BTTM- Bachelor of Travel and Tourism Management" },
                    { new Guid("f66cec31-5c36-495f-a3e8-a632a69e7f95"), 3, "Power Engineering" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("025560e1-5f25-46b5-b80e-bbabe64de8bd"), "Jessie_Gutkowski@gmail.com", "Jessie Gutkowski" },
                    { new Guid("0b46d90b-5e67-481a-ada5-5a7e7258ea16"), "Shannon.Fahey29@hotmail.com", "Shannon Fahey" },
                    { new Guid("0bbfa698-a58e-41d3-9e0c-ab305f234451"), "Angela_Smith@gmail.com", "Angela Smith" },
                    { new Guid("11133fca-5193-47a5-abe8-533c6d7c2f6a"), "Rex79@yahoo.com", "Rex Kuhlman" },
                    { new Guid("118c7a1c-6981-4d50-a2fb-b5ad7229e67b"), "Eileen97@yahoo.com", "Eileen Roberts" },
                    { new Guid("284df7d9-b086-42ea-9a2c-d5f1d1b0d649"), "Constance22@gmail.com", "Constance Kassulke" },
                    { new Guid("2ce62faf-5049-492e-8b96-a3cb2c4565be"), "Frederick_Bartell@hotmail.com", "Frederick Bartell" },
                    { new Guid("3a5d9320-0d5e-438b-b15c-da2967bd624c"), "Luis_Towne@gmail.com", "Luis Towne" },
                    { new Guid("3b6cc267-1421-4e63-9a63-be455e79cfd6"), "Marcella75@yahoo.com", "Marcella Grady" },
                    { new Guid("49184e54-00e6-40a7-91c7-817c6ad24538"), "Noel_Abernathy@hotmail.com", "Noel Abernathy" },
                    { new Guid("500d1810-5864-49e4-8b13-2d7cf80e3e76"), "Jill.Sauer41@gmail.com", "Jill Sauer" },
                    { new Guid("5781bfe3-41f5-4adf-be5f-13d9576efd55"), "Rickey_Okuneva61@gmail.com", "Rickey Okuneva" },
                    { new Guid("59669200-1e95-4f3d-bb0d-7b05012a2d4a"), "Danny_Waters@hotmail.com", "Danny Waters" },
                    { new Guid("5a50784a-c1a0-4d9e-9d2e-3350dbf762c4"), "Jeannie_Lind31@gmail.com", "Jeannie Lind" },
                    { new Guid("5b18eb20-62e9-473d-b265-91ab876a142e"), "Robyn.Rutherford@yahoo.com", "Robyn Rutherford" },
                    { new Guid("5c59c4ad-328f-4b59-9599-fb7a3662235e"), "Mabel_Schiller55@hotmail.com", "Mabel Schiller" },
                    { new Guid("5c921f64-843b-4abd-91ff-029047006111"), "Fredrick_Gusikowski@gmail.com", "Fredrick Gusikowski" },
                    { new Guid("5eef45df-e07f-40a2-b20b-a92956858580"), "Bonnie.Beer@yahoo.com", "Bonnie Beer" },
                    { new Guid("639724e7-174b-4319-a68c-222fe0df463a"), "Pablo_Price@yahoo.com", "Pablo Price" },
                    { new Guid("68bf494a-4479-4e58-bc62-2bc8c13da6e1"), "Ramona_Schneider@gmail.com", "Ramona Schneider" },
                    { new Guid("6d4a1f2e-1644-4621-a3f7-df7822ab2982"), "Judith.Mertz@hotmail.com", "Judith Mertz" },
                    { new Guid("6e58d3c9-0249-4a98-b803-87511b0757a5"), "Vicki_Waelchi@hotmail.com", "Vicki Waelchi" },
                    { new Guid("70297587-16e4-4226-8841-3a94b21bc75a"), "Joyce89@hotmail.com", "Joyce Armstrong" },
                    { new Guid("7a4298cf-ba36-4a69-b7fa-097265e2a2ef"), "May36@hotmail.com", "May Schoen" },
                    { new Guid("84e7cc19-6e5a-448c-a48e-1b38d9cf7608"), "Maxine_Luettgen5@yahoo.com", "Maxine Luettgen" },
                    { new Guid("91c5bc2a-da4a-480c-990a-6ba483d85f8a"), "Ismael.Nitzsche@hotmail.com", "Ismael Nitzsche" },
                    { new Guid("991213e8-8f7e-4a3d-9199-e02c3c5dd8e1"), "Grace87@gmail.com", "Grace Kunde" },
                    { new Guid("a4c105cc-a6e4-4e6f-9ee6-5a5c7c994aa1"), "Frederick80@hotmail.com", "Frederick Blanda" },
                    { new Guid("b237b1f8-545d-49f8-83ec-c6f9f1c7c0f4"), "Jenny.Blick@gmail.com", "Jenny Blick" },
                    { new Guid("bd5ea150-2973-406f-b7a8-b608bca698cf"), "Kerry73@gmail.com", "Kerry Gutmann" },
                    { new Guid("c0f8373b-6e54-4550-b637-470ee8201d4a"), "Frederick92@hotmail.com", "Frederick Mohr" },
                    { new Guid("c29465fe-440c-4b2e-9d0c-8ee326201783"), "John.Labadie@hotmail.com", "John Labadie" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("011f6f39-3386-492a-a976-9e1aa0190585"), new Guid("f66cec31-5c36-495f-a3e8-a632a69e7f95"), 5, new Guid("5781bfe3-41f5-4adf-be5f-13d9576efd55") },
                    { new Guid("0819683b-f394-4455-8dc0-e803e006258a"), new Guid("9a6187c0-95a6-40ca-aaa9-ac2d91a7fd65"), 5, new Guid("5a50784a-c1a0-4d9e-9d2e-3350dbf762c4") },
                    { new Guid("3c2b8474-dcba-4048-85e2-b09606ba207b"), new Guid("4e09a068-d7db-4451-aff8-bb0c4706a55b"), 4, new Guid("118c7a1c-6981-4d50-a2fb-b5ad7229e67b") },
                    { new Guid("45eaaa26-8d18-4853-97e3-bf21beb951b4"), new Guid("5bd560d4-fd65-4d8b-a29b-e78710d28e27"), 3, new Guid("5b18eb20-62e9-473d-b265-91ab876a142e") },
                    { new Guid("61296734-136c-41de-80cb-01200891afab"), new Guid("4eb78ab4-3578-4e72-b83e-643d9fc5f010"), 4, new Guid("5a50784a-c1a0-4d9e-9d2e-3350dbf762c4") },
                    { new Guid("74bd7cc9-5988-40bf-9424-00792b3436a8"), new Guid("1674c76c-ac10-46bf-955d-0f9309f7177c"), 1, new Guid("5c59c4ad-328f-4b59-9599-fb7a3662235e") },
                    { new Guid("7a5f3f70-3d04-4dc4-becf-600f3c9786d3"), new Guid("dc5dfd82-7ce4-4b3a-ad36-4ff9a47ba5c3"), 3, new Guid("c0f8373b-6e54-4550-b637-470ee8201d4a") },
                    { new Guid("7eb59d7d-85fc-4daf-9d54-75c680da825a"), new Guid("302981e8-4922-4bcb-8695-9304d754a2dc"), 3, new Guid("c29465fe-440c-4b2e-9d0c-8ee326201783") },
                    { new Guid("7f07e3ec-ecef-4700-b53a-4446b0a5d788"), new Guid("4c7a9083-5000-4739-8f6d-d94a90524173"), 5, new Guid("59669200-1e95-4f3d-bb0d-7b05012a2d4a") },
                    { new Guid("9d032a5d-845e-4a42-b33d-a8dee7933a8b"), new Guid("a7402094-4232-42b3-9022-43b49cf537d2"), 5, new Guid("025560e1-5f25-46b5-b80e-bbabe64de8bd") },
                    { new Guid("adfe1028-e2c8-4081-9622-89d9da921e6b"), new Guid("c986bce5-2f09-419c-829e-2125a44bc222"), 5, new Guid("7a4298cf-ba36-4a69-b7fa-097265e2a2ef") },
                    { new Guid("b19ec2bd-da6d-41a3-a700-5a9399597dce"), new Guid("48719fec-da6e-4132-a2e2-e55a295f666d"), 5, new Guid("284df7d9-b086-42ea-9a2c-d5f1d1b0d649") },
                    { new Guid("b3b9f85a-cc5a-403e-bf0c-fcf39873834c"), new Guid("b44b6646-9828-471f-8f4b-31775857f812"), 5, new Guid("c29465fe-440c-4b2e-9d0c-8ee326201783") },
                    { new Guid("bbb11aa3-bdb2-4ee6-b4dc-e58cf1a32af5"), new Guid("0e882e0e-06dc-49a7-ada0-869674c9b5ab"), 1, new Guid("59669200-1e95-4f3d-bb0d-7b05012a2d4a") },
                    { new Guid("c9148f41-6abb-4862-a0de-58bd8a71bcaa"), new Guid("57f07cc7-2861-449d-975a-0993c1646693"), 5, new Guid("5eef45df-e07f-40a2-b20b-a92956858580") },
                    { new Guid("d68a9699-1360-4189-89b8-80ac5c6b9077"), new Guid("cf65b6dc-99b3-4148-95da-ba5f675769b6"), 2, new Guid("c29465fe-440c-4b2e-9d0c-8ee326201783") },
                    { new Guid("d7ca0cf6-cb2c-456a-8a8f-02823eae4cc6"), new Guid("a7402094-4232-42b3-9022-43b49cf537d2"), 1, new Guid("639724e7-174b-4319-a68c-222fe0df463a") },
                    { new Guid("dc29efc7-4f20-4ba7-8928-1769b13be6f4"), new Guid("b9aa3a2c-36b8-4ab7-91e5-afdf1c901e1c"), 4, new Guid("70297587-16e4-4226-8841-3a94b21bc75a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disenrollments_CourseId",
                table: "Disenrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Disenrollments_StudentId",
                table: "Disenrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disenrollments");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
