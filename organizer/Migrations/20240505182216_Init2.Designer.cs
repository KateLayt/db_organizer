﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using organizer;

#nullable disable

namespace organizer.Migrations
{
    [DbContext(typeof(OrganizerDbContext))]
    [Migration("20240505182216_Init2")]
    partial class Init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("organizer.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentID"));

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("CommentID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("organizer.Models.RepeatableTask", b =>
                {
                    b.Property<int>("RepeatableTaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RepeatableTaskID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<int?>("TaskGroupID")
                        .HasColumnType("integer");

                    b.HasKey("RepeatableTaskID");

                    b.HasIndex("TaskGroupID");

                    b.ToTable("RepeatableTasks");
                });

            modelBuilder.Entity("organizer.Models.Task", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TaskID"));

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<int?>("TaskGroupID")
                        .HasColumnType("integer");

                    b.HasKey("TaskID");

                    b.HasIndex("TaskGroupID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("organizer.Models.TaskGroup", b =>
                {
                    b.Property<int>("TaskGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TaskGroupID"));

                    b.Property<string>("Description")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<bool>("IsBuiltin")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("TaskGroupID");

                    b.HasIndex("UserID");

                    b.ToTable("TaskGroups");

                    b.HasData(
                        new
                        {
                            TaskGroupID = -1,
                            IsBuiltin = true,
                            Name = "Уборка"
                        },
                        new
                        {
                            TaskGroupID = -2,
                            IsBuiltin = true,
                            Name = "Продукты"
                        },
                        new
                        {
                            TaskGroupID = -3,
                            IsBuiltin = true,
                            Name = "Работа"
                        },
                        new
                        {
                            TaskGroupID = -4,
                            IsBuiltin = true,
                            Name = "Прочее"
                        });
                });

            modelBuilder.Entity("organizer.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<int?>("AvatarID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("IsMale")
                        .IsRequired()
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("organizer.Models.Comment", b =>
                {
                    b.HasOne("organizer.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer.Models.RepeatableTask", b =>
                {
                    b.HasOne("organizer.Models.TaskGroup", "TaskGroup")
                        .WithMany("RepeatableTasks")
                        .HasForeignKey("TaskGroupID");

                    b.Navigation("TaskGroup");
                });

            modelBuilder.Entity("organizer.Models.Task", b =>
                {
                    b.HasOne("organizer.Models.TaskGroup", "TaskGroup")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskGroupID");

                    b.Navigation("TaskGroup");
                });

            modelBuilder.Entity("organizer.Models.TaskGroup", b =>
                {
                    b.HasOne("organizer.Models.User", "User")
                        .WithMany("TaskGroups")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer.Models.TaskGroup", b =>
                {
                    b.Navigation("RepeatableTasks");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("organizer.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("TaskGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
