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
                    { new Guid("0c8ceb7e-66fa-43b4-ad09-335780d9c69e"), 15, "Integrated Law Course- BA + LL.B" },
                    { new Guid("13206b64-7ce9-4c60-ba9a-26901801d98a"), 17, "Integrated Law Course- BA + LL.B" },
                    { new Guid("3a85183e-0c05-4318-8954-61ee51c2e556"), 15, "Automation and Robotics" },
                    { new Guid("3efb0b2a-2d28-4a66-98be-0fa0c76b88f4"), 7, "Smart Manufacturing & Automation" },
                    { new Guid("441bad45-0210-4b10-9400-fb837d0cc882"), 0, "Electronics and Communication Engineering" },
                    { new Guid("548e12bb-3c5c-4b16-83d5-ccf7d97b64f1"), 3, "Electronics and Communication Engineering" },
                    { new Guid("5709a63e-2147-429b-b469-50e94e4f0274"), 18, "BBA- Bachelor of Business Administration" },
                    { new Guid("58416d7d-b4ac-4dc9-8caa-1896fb1662d0"), 27, "Instrumentation Engineering" },
                    { new Guid("5b2a9265-f808-4819-ad25-d01024799a07"), 27, "Biotechnology Engineering" },
                    { new Guid("5ba1a0ed-557f-4c13-9bb7-a3c0bda3ca14"), 7, "Bachelor of Performing Arts" },
                    { new Guid("5d36409f-f048-4702-9578-47becb456993"), 2, "Automobile Engineering" },
                    { new Guid("6a99f5c5-a950-4e5f-9609-4cd35802ecdb"), 14, "BFD- Bachelor of Fashion Designing" },
                    { new Guid("7a3c9b63-c59b-4b05-b25b-abe81df898c3"), 10, "Robotics Engineering" },
                    { new Guid("7fb753bf-ec2a-40be-b6a8-3575b6bd9a77"), 20, "BA in History" },
                    { new Guid("86ba7de5-8f0a-4eb3-90e0-e7a664b7fe45"), 29, "Aviation Courses" },
                    { new Guid("8d1a8d41-3931-4931-9c7c-ea7043840b34"), 24, "BTTM- Bachelor of Travel and Tourism Management" },
                    { new Guid("8fb6f4cd-4d17-485a-b511-4f3766ae3376"), 5, "BJMC- Bachelor of Journalism and Mass Communication" },
                    { new Guid("935b1e24-e113-4a75-bc43-57275dd117b6"), 8, "Computer Science and Engineering" },
                    { new Guid("9515aeaf-9cfc-4da6-a7f0-71c28a41d5d0"), 20, "Electrical and Electronics Engineering" },
                    { new Guid("9b337bf3-ba4c-481a-9f83-0c380cf77b60"), 21, "Aeronautical Engineering" },
                    { new Guid("9dbdd5e1-2b91-48f8-9490-9c63b261c14b"), 25, "Computer Science and Engineering" },
                    { new Guid("a98c68f0-3093-49ad-8e0c-efdd76bdf81e"), 23, "Bachelor of Performing Arts" },
                    { new Guid("aba04699-05ed-437d-8a37-87d44b8ed223"), 3, "Integrated Law Course- BA + LL.B" },
                    { new Guid("ac98a6dc-022f-40bf-86e4-d2bc39651505"), 10, "BTTM- Bachelor of Travel and Tourism Management" },
                    { new Guid("b358c666-296c-491b-8c1a-128cb621904b"), 2, "Robotics Engineering" },
                    { new Guid("baf53d9d-0c69-4359-9218-c9d7ae53c684"), 22, "Smart Manufacturing & Automation" },
                    { new Guid("c71ff324-ae1f-4475-b239-7ac11d6d1c93"), 3, "Electronics and Communication Engineering" },
                    { new Guid("cac28166-63c9-463c-8fc8-8cde01859c68"), 17, "Instrumentation Engineering" },
                    { new Guid("e44f47a9-2838-4d19-8e58-d5521b7c4f98"), 8, "BSW- Bachelor of Social Work" },
                    { new Guid("f0f38101-354b-4261-b73f-7a3ae1fea292"), 2, "Electronics and Communication Engineering" },
                    { new Guid("fad3329c-f8de-4490-84f3-5a6a64d7d528"), 15, "Smart Manufacturing & Automation" },
                    { new Guid("fcc5b72a-4154-4511-9695-dd7ffb587bd6"), 16, "Electronics and Communication Engineering" },
                    { new Guid("fff19f9b-072d-449e-877b-27e6de73f1f5"), 17, "BMS- Bachelor of Management Science" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("1e175458-138f-47c5-9c1f-77e521473ba8"), "Pete_Schmidt16@gmail.com", "Pete Schmidt" },
                    { new Guid("1f472f2f-8028-402e-9ae2-9917d525e24f"), "Mitchell_Mann86@hotmail.com", "Mitchell Mann" },
                    { new Guid("2436ed8e-9952-4117-9026-8fba2a994f97"), "Tammy11@yahoo.com", "Tammy Price" },
                    { new Guid("2477eaf0-2891-4439-b124-8e4ff541911e"), "Joann.Brekke5@hotmail.com", "Joann Brekke" },
                    { new Guid("272b8e0b-37ea-48d5-8399-1ce6e76b02ac"), "Mandy.Mann@hotmail.com", "Mandy Mann" },
                    { new Guid("33079df0-4731-4861-8311-caa768edfa44"), "Dianna40@yahoo.com", "Dianna Hahn" },
                    { new Guid("4dba6146-33bf-492a-acb3-0d38870a0299"), "Aubrey37@gmail.com", "Aubrey Ritchie" },
                    { new Guid("50d0b7e0-1967-4fd6-a1db-bdc3c0262f71"), "Erik28@gmail.com", "Erik Grant" },
                    { new Guid("5b732ae3-7dcc-4e27-8abb-0dc6fecc2435"), "Neal34@yahoo.com", "Neal Brekke" },
                    { new Guid("62e7599a-5fde-4c58-87b5-f6067579014f"), "Bradford_Gutmann74@yahoo.com", "Bradford Gutmann" },
                    { new Guid("7bf1f5ad-ebd4-4cea-8aeb-5022247bc2a8"), "Cecilia14@yahoo.com", "Cecilia Hamill" },
                    { new Guid("7c65faba-be2a-4a54-99b6-cce290cc3544"), "Alvin76@gmail.com", "Alvin Ruecker" },
                    { new Guid("84329d64-6ee8-4f15-99c7-993dcaa1bba5"), "Lillian.Block@hotmail.com", "Lillian Block" },
                    { new Guid("860327eb-5201-46f4-bb71-0b7c70b757c0"), "Donnie.Koepp@hotmail.com", "Donnie Koepp" },
                    { new Guid("94f85bd0-6399-4609-9341-addfbe2337b2"), "Rogelio_Cronin30@hotmail.com", "Rogelio Cronin" },
                    { new Guid("980ef0eb-efcb-4a1d-8b1b-a243bd243d45"), "Melvin.Bradtke30@gmail.com", "Melvin Bradtke" },
                    { new Guid("9922a7d7-ccb1-4461-82de-8e38a7687c61"), "Clyde.Bahringer12@yahoo.com", "Clyde Bahringer" },
                    { new Guid("9bf6d2d3-3f57-47ab-9dc1-75d90b22dcd8"), "Colleen.Deckow88@gmail.com", "Colleen Deckow" },
                    { new Guid("9eb22e2d-00a3-4696-b964-94281b743330"), "Michael.Wilderman@gmail.com", "Michael Wilderman" },
                    { new Guid("a832321b-4c87-4aab-abd7-197caeb344d3"), "Jaime_Schultz@hotmail.com", "Jaime Schultz" },
                    { new Guid("a92bc102-d1a3-403c-9022-bfd0bd992c0f"), "Angelica_Zieme@yahoo.com", "Angelica Zieme" },
                    { new Guid("b4695386-76f9-40e5-8ed2-6c5c0784ec09"), "Gertrude.Keeling93@yahoo.com", "Gertrude Keeling" },
                    { new Guid("b6159067-84dc-4bcc-93e8-aeba27aac639"), "Mercedes55@yahoo.com", "Mercedes Weimann" },
                    { new Guid("bd009bcf-ec30-4ff0-8751-5a4b60265822"), "Caroline86@yahoo.com", "Caroline Emard" },
                    { new Guid("ceafa970-a60a-4077-976b-f2cef95d9bff"), "Gilbert.Stamm3@gmail.com", "Gilbert Stamm" },
                    { new Guid("d056b978-5fb7-4bdc-b48d-fcd3fdaed136"), "Suzanne_Gutkowski@gmail.com", "Suzanne Gutkowski" },
                    { new Guid("d80b8a53-c437-4a04-8257-8a69e13aaeb1"), "Guillermo55@yahoo.com", "Guillermo Bruen" },
                    { new Guid("e03304b2-5a8a-49be-b0db-f9eb8629e091"), "Tommy.Hilpert@hotmail.com", "Tommy Hilpert" },
                    { new Guid("efdbcfa8-aca1-4982-8ce6-44be17c2b689"), "Georgia.Beahan8@yahoo.com", "Georgia Beahan" },
                    { new Guid("efedf3b4-d984-41d1-8174-c063123d8f19"), "Randall.Bergnaum51@yahoo.com", "Randall Bergnaum" },
                    { new Guid("f75b369a-2482-4d9c-9e3f-e82b075433a8"), "Ernestine99@gmail.com", "Ernestine Cassin" },
                    { new Guid("f83b4f1e-5281-41c3-af1a-c42d2ddf602a"), "Dianna.Gulgowski55@gmail.com", "Dianna Gulgowski" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("08907470-b666-4215-843d-a0a4c3bff7fa"), new Guid("fad3329c-f8de-4490-84f3-5a6a64d7d528"), 5, new Guid("b6159067-84dc-4bcc-93e8-aeba27aac639") },
                    { new Guid("0a2aaa04-113a-4fba-8baf-0cdbeb391329"), new Guid("8fb6f4cd-4d17-485a-b511-4f3766ae3376"), 1, new Guid("62e7599a-5fde-4c58-87b5-f6067579014f") },
                    { new Guid("110f87f0-fa56-401e-bb6b-9054b9307903"), new Guid("fcc5b72a-4154-4511-9695-dd7ffb587bd6"), 5, new Guid("5b732ae3-7dcc-4e27-8abb-0dc6fecc2435") },
                    { new Guid("18b45c63-00b9-4c1e-a45d-6134f40f36f2"), new Guid("8d1a8d41-3931-4931-9c7c-ea7043840b34"), 2, new Guid("9bf6d2d3-3f57-47ab-9dc1-75d90b22dcd8") },
                    { new Guid("4168efa4-b790-43f9-8194-67eee161b0d5"), new Guid("5709a63e-2147-429b-b469-50e94e4f0274"), 1, new Guid("efdbcfa8-aca1-4982-8ce6-44be17c2b689") },
                    { new Guid("4271238b-dc02-49d8-807c-375bbbbb7bd9"), new Guid("3efb0b2a-2d28-4a66-98be-0fa0c76b88f4"), 5, new Guid("ceafa970-a60a-4077-976b-f2cef95d9bff") },
                    { new Guid("53e4df4f-5ba2-4207-836a-e4551a05ab2c"), new Guid("fff19f9b-072d-449e-877b-27e6de73f1f5"), 4, new Guid("62e7599a-5fde-4c58-87b5-f6067579014f") },
                    { new Guid("5c88aba5-fa6b-4e5a-a95f-e829b55f904f"), new Guid("ac98a6dc-022f-40bf-86e4-d2bc39651505"), 5, new Guid("b4695386-76f9-40e5-8ed2-6c5c0784ec09") },
                    { new Guid("60daa9b5-8f37-4097-80db-96fb07b2cb33"), new Guid("0c8ceb7e-66fa-43b4-ad09-335780d9c69e"), 3, new Guid("84329d64-6ee8-4f15-99c7-993dcaa1bba5") },
                    { new Guid("74284385-a7a5-409e-bafa-6b5e6afc8e48"), new Guid("fad3329c-f8de-4490-84f3-5a6a64d7d528"), 3, new Guid("f75b369a-2482-4d9c-9e3f-e82b075433a8") },
                    { new Guid("755f3a83-bba9-439b-b7c6-dfcfe7e2dfb5"), new Guid("9515aeaf-9cfc-4da6-a7f0-71c28a41d5d0"), 2, new Guid("a92bc102-d1a3-403c-9022-bfd0bd992c0f") },
                    { new Guid("7898c605-9d3d-4eac-b629-7570705fef72"), new Guid("441bad45-0210-4b10-9400-fb837d0cc882"), 4, new Guid("b6159067-84dc-4bcc-93e8-aeba27aac639") },
                    { new Guid("7c93f27e-e970-4fde-b290-283715d2a2fa"), new Guid("86ba7de5-8f0a-4eb3-90e0-e7a664b7fe45"), 4, new Guid("94f85bd0-6399-4609-9341-addfbe2337b2") },
                    { new Guid("97120624-a474-488c-acd9-935ce6cff58e"), new Guid("f0f38101-354b-4261-b73f-7a3ae1fea292"), 2, new Guid("4dba6146-33bf-492a-acb3-0d38870a0299") },
                    { new Guid("a9a97e7d-f5d3-4f83-819e-c883d2245378"), new Guid("935b1e24-e113-4a75-bc43-57275dd117b6"), 4, new Guid("980ef0eb-efcb-4a1d-8b1b-a243bd243d45") },
                    { new Guid("daf232ef-84f2-42f6-bf32-695e9ce4c995"), new Guid("5ba1a0ed-557f-4c13-9bb7-a3c0bda3ca14"), 5, new Guid("efdbcfa8-aca1-4982-8ce6-44be17c2b689") },
                    { new Guid("ea6ff7b2-a78a-4bc5-8181-29f8c316bae1"), new Guid("5709a63e-2147-429b-b469-50e94e4f0274"), 2, new Guid("2477eaf0-2891-4439-b124-8e4ff541911e") },
                    { new Guid("f6314385-6857-47a7-9ad5-18fb03d7fe1a"), new Guid("0c8ceb7e-66fa-43b4-ad09-335780d9c69e"), 3, new Guid("d80b8a53-c437-4a04-8257-8a69e13aaeb1") },
                    { new Guid("ff97ce85-c788-4149-ad28-3e1820ea9ab2"), new Guid("cac28166-63c9-463c-8fc8-8cde01859c68"), 1, new Guid("a92bc102-d1a3-403c-9022-bfd0bd992c0f") }
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
