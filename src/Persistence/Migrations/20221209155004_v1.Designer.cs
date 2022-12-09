﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Database;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20221209155004_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentManagementSystem.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Credits")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5709a63e-2147-429b-b469-50e94e4f0274"),
                            Credits = 18,
                            Name = "BBA- Bachelor of Business Administration"
                        },
                        new
                        {
                            Id = new Guid("aba04699-05ed-437d-8a37-87d44b8ed223"),
                            Credits = 3,
                            Name = "Integrated Law Course- BA + LL.B"
                        },
                        new
                        {
                            Id = new Guid("548e12bb-3c5c-4b16-83d5-ccf7d97b64f1"),
                            Credits = 3,
                            Name = "Electronics and Communication Engineering"
                        },
                        new
                        {
                            Id = new Guid("86ba7de5-8f0a-4eb3-90e0-e7a664b7fe45"),
                            Credits = 29,
                            Name = "Aviation Courses"
                        },
                        new
                        {
                            Id = new Guid("7fb753bf-ec2a-40be-b6a8-3575b6bd9a77"),
                            Credits = 20,
                            Name = "BA in History"
                        },
                        new
                        {
                            Id = new Guid("c71ff324-ae1f-4475-b239-7ac11d6d1c93"),
                            Credits = 3,
                            Name = "Electronics and Communication Engineering"
                        },
                        new
                        {
                            Id = new Guid("3a85183e-0c05-4318-8954-61ee51c2e556"),
                            Credits = 15,
                            Name = "Automation and Robotics"
                        },
                        new
                        {
                            Id = new Guid("441bad45-0210-4b10-9400-fb837d0cc882"),
                            Credits = 0,
                            Name = "Electronics and Communication Engineering"
                        },
                        new
                        {
                            Id = new Guid("5b2a9265-f808-4819-ad25-d01024799a07"),
                            Credits = 27,
                            Name = "Biotechnology Engineering"
                        },
                        new
                        {
                            Id = new Guid("9dbdd5e1-2b91-48f8-9490-9c63b261c14b"),
                            Credits = 25,
                            Name = "Computer Science and Engineering"
                        },
                        new
                        {
                            Id = new Guid("5ba1a0ed-557f-4c13-9bb7-a3c0bda3ca14"),
                            Credits = 7,
                            Name = "Bachelor of Performing Arts"
                        },
                        new
                        {
                            Id = new Guid("3efb0b2a-2d28-4a66-98be-0fa0c76b88f4"),
                            Credits = 7,
                            Name = "Smart Manufacturing & Automation"
                        },
                        new
                        {
                            Id = new Guid("fff19f9b-072d-449e-877b-27e6de73f1f5"),
                            Credits = 17,
                            Name = "BMS- Bachelor of Management Science"
                        },
                        new
                        {
                            Id = new Guid("6a99f5c5-a950-4e5f-9609-4cd35802ecdb"),
                            Credits = 14,
                            Name = "BFD- Bachelor of Fashion Designing"
                        },
                        new
                        {
                            Id = new Guid("cac28166-63c9-463c-8fc8-8cde01859c68"),
                            Credits = 17,
                            Name = "Instrumentation Engineering"
                        },
                        new
                        {
                            Id = new Guid("fad3329c-f8de-4490-84f3-5a6a64d7d528"),
                            Credits = 15,
                            Name = "Smart Manufacturing & Automation"
                        },
                        new
                        {
                            Id = new Guid("fcc5b72a-4154-4511-9695-dd7ffb587bd6"),
                            Credits = 16,
                            Name = "Electronics and Communication Engineering"
                        },
                        new
                        {
                            Id = new Guid("9515aeaf-9cfc-4da6-a7f0-71c28a41d5d0"),
                            Credits = 20,
                            Name = "Electrical and Electronics Engineering"
                        },
                        new
                        {
                            Id = new Guid("8d1a8d41-3931-4931-9c7c-ea7043840b34"),
                            Credits = 24,
                            Name = "BTTM- Bachelor of Travel and Tourism Management"
                        },
                        new
                        {
                            Id = new Guid("e44f47a9-2838-4d19-8e58-d5521b7c4f98"),
                            Credits = 8,
                            Name = "BSW- Bachelor of Social Work"
                        },
                        new
                        {
                            Id = new Guid("9b337bf3-ba4c-481a-9f83-0c380cf77b60"),
                            Credits = 21,
                            Name = "Aeronautical Engineering"
                        },
                        new
                        {
                            Id = new Guid("13206b64-7ce9-4c60-ba9a-26901801d98a"),
                            Credits = 17,
                            Name = "Integrated Law Course- BA + LL.B"
                        },
                        new
                        {
                            Id = new Guid("f0f38101-354b-4261-b73f-7a3ae1fea292"),
                            Credits = 2,
                            Name = "Electronics and Communication Engineering"
                        },
                        new
                        {
                            Id = new Guid("b358c666-296c-491b-8c1a-128cb621904b"),
                            Credits = 2,
                            Name = "Robotics Engineering"
                        },
                        new
                        {
                            Id = new Guid("5d36409f-f048-4702-9578-47becb456993"),
                            Credits = 2,
                            Name = "Automobile Engineering"
                        },
                        new
                        {
                            Id = new Guid("baf53d9d-0c69-4359-9218-c9d7ae53c684"),
                            Credits = 22,
                            Name = "Smart Manufacturing & Automation"
                        },
                        new
                        {
                            Id = new Guid("ac98a6dc-022f-40bf-86e4-d2bc39651505"),
                            Credits = 10,
                            Name = "BTTM- Bachelor of Travel and Tourism Management"
                        },
                        new
                        {
                            Id = new Guid("7a3c9b63-c59b-4b05-b25b-abe81df898c3"),
                            Credits = 10,
                            Name = "Robotics Engineering"
                        },
                        new
                        {
                            Id = new Guid("0c8ceb7e-66fa-43b4-ad09-335780d9c69e"),
                            Credits = 15,
                            Name = "Integrated Law Course- BA + LL.B"
                        },
                        new
                        {
                            Id = new Guid("a98c68f0-3093-49ad-8e0c-efdd76bdf81e"),
                            Credits = 23,
                            Name = "Bachelor of Performing Arts"
                        },
                        new
                        {
                            Id = new Guid("58416d7d-b4ac-4dc9-8caa-1896fb1662d0"),
                            Credits = 27,
                            Name = "Instrumentation Engineering"
                        },
                        new
                        {
                            Id = new Guid("935b1e24-e113-4a75-bc43-57275dd117b6"),
                            Credits = 8,
                            Name = "Computer Science and Engineering"
                        },
                        new
                        {
                            Id = new Guid("8fb6f4cd-4d17-485a-b511-4f3766ae3376"),
                            Credits = 5,
                            Name = "BJMC- Bachelor of Journalism and Mass Communication"
                        });
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Disenrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Disenrollments");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("97120624-a474-488c-acd9-935ce6cff58e"),
                            CourseId = new Guid("f0f38101-354b-4261-b73f-7a3ae1fea292"),
                            Grade = 2,
                            StudentId = new Guid("4dba6146-33bf-492a-acb3-0d38870a0299")
                        },
                        new
                        {
                            Id = new Guid("4271238b-dc02-49d8-807c-375bbbbb7bd9"),
                            CourseId = new Guid("3efb0b2a-2d28-4a66-98be-0fa0c76b88f4"),
                            Grade = 5,
                            StudentId = new Guid("ceafa970-a60a-4077-976b-f2cef95d9bff")
                        },
                        new
                        {
                            Id = new Guid("4168efa4-b790-43f9-8194-67eee161b0d5"),
                            CourseId = new Guid("5709a63e-2147-429b-b469-50e94e4f0274"),
                            Grade = 1,
                            StudentId = new Guid("efdbcfa8-aca1-4982-8ce6-44be17c2b689")
                        },
                        new
                        {
                            Id = new Guid("755f3a83-bba9-439b-b7c6-dfcfe7e2dfb5"),
                            CourseId = new Guid("9515aeaf-9cfc-4da6-a7f0-71c28a41d5d0"),
                            Grade = 2,
                            StudentId = new Guid("a92bc102-d1a3-403c-9022-bfd0bd992c0f")
                        },
                        new
                        {
                            Id = new Guid("110f87f0-fa56-401e-bb6b-9054b9307903"),
                            CourseId = new Guid("fcc5b72a-4154-4511-9695-dd7ffb587bd6"),
                            Grade = 5,
                            StudentId = new Guid("5b732ae3-7dcc-4e27-8abb-0dc6fecc2435")
                        },
                        new
                        {
                            Id = new Guid("f6314385-6857-47a7-9ad5-18fb03d7fe1a"),
                            CourseId = new Guid("0c8ceb7e-66fa-43b4-ad09-335780d9c69e"),
                            Grade = 3,
                            StudentId = new Guid("d80b8a53-c437-4a04-8257-8a69e13aaeb1")
                        },
                        new
                        {
                            Id = new Guid("ff97ce85-c788-4149-ad28-3e1820ea9ab2"),
                            CourseId = new Guid("cac28166-63c9-463c-8fc8-8cde01859c68"),
                            Grade = 1,
                            StudentId = new Guid("a92bc102-d1a3-403c-9022-bfd0bd992c0f")
                        },
                        new
                        {
                            Id = new Guid("18b45c63-00b9-4c1e-a45d-6134f40f36f2"),
                            CourseId = new Guid("8d1a8d41-3931-4931-9c7c-ea7043840b34"),
                            Grade = 2,
                            StudentId = new Guid("9bf6d2d3-3f57-47ab-9dc1-75d90b22dcd8")
                        },
                        new
                        {
                            Id = new Guid("0a2aaa04-113a-4fba-8baf-0cdbeb391329"),
                            CourseId = new Guid("8fb6f4cd-4d17-485a-b511-4f3766ae3376"),
                            Grade = 1,
                            StudentId = new Guid("62e7599a-5fde-4c58-87b5-f6067579014f")
                        },
                        new
                        {
                            Id = new Guid("74284385-a7a5-409e-bafa-6b5e6afc8e48"),
                            CourseId = new Guid("fad3329c-f8de-4490-84f3-5a6a64d7d528"),
                            Grade = 3,
                            StudentId = new Guid("f75b369a-2482-4d9c-9e3f-e82b075433a8")
                        },
                        new
                        {
                            Id = new Guid("60daa9b5-8f37-4097-80db-96fb07b2cb33"),
                            CourseId = new Guid("0c8ceb7e-66fa-43b4-ad09-335780d9c69e"),
                            Grade = 3,
                            StudentId = new Guid("84329d64-6ee8-4f15-99c7-993dcaa1bba5")
                        },
                        new
                        {
                            Id = new Guid("7898c605-9d3d-4eac-b629-7570705fef72"),
                            CourseId = new Guid("441bad45-0210-4b10-9400-fb837d0cc882"),
                            Grade = 4,
                            StudentId = new Guid("b6159067-84dc-4bcc-93e8-aeba27aac639")
                        },
                        new
                        {
                            Id = new Guid("7c93f27e-e970-4fde-b290-283715d2a2fa"),
                            CourseId = new Guid("86ba7de5-8f0a-4eb3-90e0-e7a664b7fe45"),
                            Grade = 4,
                            StudentId = new Guid("94f85bd0-6399-4609-9341-addfbe2337b2")
                        },
                        new
                        {
                            Id = new Guid("a9a97e7d-f5d3-4f83-819e-c883d2245378"),
                            CourseId = new Guid("935b1e24-e113-4a75-bc43-57275dd117b6"),
                            Grade = 4,
                            StudentId = new Guid("980ef0eb-efcb-4a1d-8b1b-a243bd243d45")
                        },
                        new
                        {
                            Id = new Guid("08907470-b666-4215-843d-a0a4c3bff7fa"),
                            CourseId = new Guid("fad3329c-f8de-4490-84f3-5a6a64d7d528"),
                            Grade = 5,
                            StudentId = new Guid("b6159067-84dc-4bcc-93e8-aeba27aac639")
                        },
                        new
                        {
                            Id = new Guid("daf232ef-84f2-42f6-bf32-695e9ce4c995"),
                            CourseId = new Guid("5ba1a0ed-557f-4c13-9bb7-a3c0bda3ca14"),
                            Grade = 5,
                            StudentId = new Guid("efdbcfa8-aca1-4982-8ce6-44be17c2b689")
                        },
                        new
                        {
                            Id = new Guid("53e4df4f-5ba2-4207-836a-e4551a05ab2c"),
                            CourseId = new Guid("fff19f9b-072d-449e-877b-27e6de73f1f5"),
                            Grade = 4,
                            StudentId = new Guid("62e7599a-5fde-4c58-87b5-f6067579014f")
                        },
                        new
                        {
                            Id = new Guid("5c88aba5-fa6b-4e5a-a95f-e829b55f904f"),
                            CourseId = new Guid("ac98a6dc-022f-40bf-86e4-d2bc39651505"),
                            Grade = 5,
                            StudentId = new Guid("b4695386-76f9-40e5-8ed2-6c5c0784ec09")
                        },
                        new
                        {
                            Id = new Guid("ea6ff7b2-a78a-4bc5-8181-29f8c316bae1"),
                            CourseId = new Guid("5709a63e-2147-429b-b469-50e94e4f0274"),
                            Grade = 2,
                            StudentId = new Guid("2477eaf0-2891-4439-b124-8e4ff541911e")
                        });
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d80b8a53-c437-4a04-8257-8a69e13aaeb1"),
                            Email = "Guillermo55@yahoo.com",
                            Name = "Guillermo Bruen"
                        },
                        new
                        {
                            Id = new Guid("272b8e0b-37ea-48d5-8399-1ce6e76b02ac"),
                            Email = "Mandy.Mann@hotmail.com",
                            Name = "Mandy Mann"
                        },
                        new
                        {
                            Id = new Guid("efdbcfa8-aca1-4982-8ce6-44be17c2b689"),
                            Email = "Georgia.Beahan8@yahoo.com",
                            Name = "Georgia Beahan"
                        },
                        new
                        {
                            Id = new Guid("7bf1f5ad-ebd4-4cea-8aeb-5022247bc2a8"),
                            Email = "Cecilia14@yahoo.com",
                            Name = "Cecilia Hamill"
                        },
                        new
                        {
                            Id = new Guid("b6159067-84dc-4bcc-93e8-aeba27aac639"),
                            Email = "Mercedes55@yahoo.com",
                            Name = "Mercedes Weimann"
                        },
                        new
                        {
                            Id = new Guid("f75b369a-2482-4d9c-9e3f-e82b075433a8"),
                            Email = "Ernestine99@gmail.com",
                            Name = "Ernestine Cassin"
                        },
                        new
                        {
                            Id = new Guid("62e7599a-5fde-4c58-87b5-f6067579014f"),
                            Email = "Bradford_Gutmann74@yahoo.com",
                            Name = "Bradford Gutmann"
                        },
                        new
                        {
                            Id = new Guid("ceafa970-a60a-4077-976b-f2cef95d9bff"),
                            Email = "Gilbert.Stamm3@gmail.com",
                            Name = "Gilbert Stamm"
                        },
                        new
                        {
                            Id = new Guid("f83b4f1e-5281-41c3-af1a-c42d2ddf602a"),
                            Email = "Dianna.Gulgowski55@gmail.com",
                            Name = "Dianna Gulgowski"
                        },
                        new
                        {
                            Id = new Guid("b4695386-76f9-40e5-8ed2-6c5c0784ec09"),
                            Email = "Gertrude.Keeling93@yahoo.com",
                            Name = "Gertrude Keeling"
                        },
                        new
                        {
                            Id = new Guid("2477eaf0-2891-4439-b124-8e4ff541911e"),
                            Email = "Joann.Brekke5@hotmail.com",
                            Name = "Joann Brekke"
                        },
                        new
                        {
                            Id = new Guid("1e175458-138f-47c5-9c1f-77e521473ba8"),
                            Email = "Pete_Schmidt16@gmail.com",
                            Name = "Pete Schmidt"
                        },
                        new
                        {
                            Id = new Guid("94f85bd0-6399-4609-9341-addfbe2337b2"),
                            Email = "Rogelio_Cronin30@hotmail.com",
                            Name = "Rogelio Cronin"
                        },
                        new
                        {
                            Id = new Guid("2436ed8e-9952-4117-9026-8fba2a994f97"),
                            Email = "Tammy11@yahoo.com",
                            Name = "Tammy Price"
                        },
                        new
                        {
                            Id = new Guid("5b732ae3-7dcc-4e27-8abb-0dc6fecc2435"),
                            Email = "Neal34@yahoo.com",
                            Name = "Neal Brekke"
                        },
                        new
                        {
                            Id = new Guid("84329d64-6ee8-4f15-99c7-993dcaa1bba5"),
                            Email = "Lillian.Block@hotmail.com",
                            Name = "Lillian Block"
                        },
                        new
                        {
                            Id = new Guid("33079df0-4731-4861-8311-caa768edfa44"),
                            Email = "Dianna40@yahoo.com",
                            Name = "Dianna Hahn"
                        },
                        new
                        {
                            Id = new Guid("4dba6146-33bf-492a-acb3-0d38870a0299"),
                            Email = "Aubrey37@gmail.com",
                            Name = "Aubrey Ritchie"
                        },
                        new
                        {
                            Id = new Guid("bd009bcf-ec30-4ff0-8751-5a4b60265822"),
                            Email = "Caroline86@yahoo.com",
                            Name = "Caroline Emard"
                        },
                        new
                        {
                            Id = new Guid("9bf6d2d3-3f57-47ab-9dc1-75d90b22dcd8"),
                            Email = "Colleen.Deckow88@gmail.com",
                            Name = "Colleen Deckow"
                        },
                        new
                        {
                            Id = new Guid("efedf3b4-d984-41d1-8174-c063123d8f19"),
                            Email = "Randall.Bergnaum51@yahoo.com",
                            Name = "Randall Bergnaum"
                        },
                        new
                        {
                            Id = new Guid("d056b978-5fb7-4bdc-b48d-fcd3fdaed136"),
                            Email = "Suzanne_Gutkowski@gmail.com",
                            Name = "Suzanne Gutkowski"
                        },
                        new
                        {
                            Id = new Guid("50d0b7e0-1967-4fd6-a1db-bdc3c0262f71"),
                            Email = "Erik28@gmail.com",
                            Name = "Erik Grant"
                        },
                        new
                        {
                            Id = new Guid("9eb22e2d-00a3-4696-b964-94281b743330"),
                            Email = "Michael.Wilderman@gmail.com",
                            Name = "Michael Wilderman"
                        },
                        new
                        {
                            Id = new Guid("980ef0eb-efcb-4a1d-8b1b-a243bd243d45"),
                            Email = "Melvin.Bradtke30@gmail.com",
                            Name = "Melvin Bradtke"
                        },
                        new
                        {
                            Id = new Guid("a92bc102-d1a3-403c-9022-bfd0bd992c0f"),
                            Email = "Angelica_Zieme@yahoo.com",
                            Name = "Angelica Zieme"
                        },
                        new
                        {
                            Id = new Guid("860327eb-5201-46f4-bb71-0b7c70b757c0"),
                            Email = "Donnie.Koepp@hotmail.com",
                            Name = "Donnie Koepp"
                        },
                        new
                        {
                            Id = new Guid("e03304b2-5a8a-49be-b0db-f9eb8629e091"),
                            Email = "Tommy.Hilpert@hotmail.com",
                            Name = "Tommy Hilpert"
                        },
                        new
                        {
                            Id = new Guid("9922a7d7-ccb1-4461-82de-8e38a7687c61"),
                            Email = "Clyde.Bahringer12@yahoo.com",
                            Name = "Clyde Bahringer"
                        },
                        new
                        {
                            Id = new Guid("7c65faba-be2a-4a54-99b6-cce290cc3544"),
                            Email = "Alvin76@gmail.com",
                            Name = "Alvin Ruecker"
                        },
                        new
                        {
                            Id = new Guid("a832321b-4c87-4aab-abd7-197caeb344d3"),
                            Email = "Jaime_Schultz@hotmail.com",
                            Name = "Jaime Schultz"
                        },
                        new
                        {
                            Id = new Guid("1f472f2f-8028-402e-9ae2-9917d525e24f"),
                            Email = "Mitchell_Mann86@hotmail.com",
                            Name = "Mitchell Mann"
                        });
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Disenrollment", b =>
                {
                    b.HasOne("StudentManagementSystem.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementSystem.Entities.Student", "Student")
                        .WithMany("Disenrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Enrollment", b =>
                {
                    b.HasOne("StudentManagementSystem.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementSystem.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Student", b =>
                {
                    b.Navigation("Disenrollments");

                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}