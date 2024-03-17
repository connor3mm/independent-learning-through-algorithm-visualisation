﻿// <auto-generated />
using System;
using API_University_Dissertation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_University_Dissertation.MigrationsQuizQuestions
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240316151552_ProficiencyScore")]
    partial class ProficiencyScore
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.2.23480.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_University_Dissertation.Core.Data.Entities.ProficiencyLevel", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LevelId"));

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("LevelId");

                    b.ToTable("ProficiencyLevels");

                    b.HasData(
                        new
                        {
                            LevelId = 1,
                            LevelName = "Undetermined"
                        },
                        new
                        {
                            LevelId = 2,
                            LevelName = "Beginner"
                        },
                        new
                        {
                            LevelId = 3,
                            LevelName = "Intermediate"
                        },
                        new
                        {
                            LevelId = 4,
                            LevelName = "Advanced"
                        });
                });

            modelBuilder.Entity("API_University_Dissertation.Core.Data.Entities.QuestionChoices", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Choice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionChoices");
                });

            modelBuilder.Entity("API_University_Dissertation.Core.Data.Entities.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("QuestionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Complexity"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Sorting Algorithms"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Searching Algorithms"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Other"
                        });
                });

            modelBuilder.Entity("API_University_Dissertation.Core.Data.Entities.QuizQuestions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QuestionTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QuestionTypeId");

                    b.ToTable("QuizQuestions");
                });

            modelBuilder.Entity("API_University_Dissertation.Core.Data.Entities.UserProfile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProficiencyLevelId")
                        .HasColumnType("integer");

                    b.Property<int>("ProficiencyScore")
                        .HasColumnType("integer");

                    b.Property<string>("UserUUID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("API_University_Dissertation.Core.Data.Entities.UserQuizStatistics", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("QuizLength")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<string>("UserUUID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("UserQuizStatistics");
                });

            modelBuilder.Entity("API_University_Dissertation.Core.Data.Entities.QuestionChoices", b =>
                {
                    b.HasOne("API_University_Dissertation.Core.Data.Entities.QuizQuestions", "QuizQuestion")
                        .WithMany("QuestionChoices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuizQuestion");
                });

            modelBuilder.Entity("API_University_Dissertation.Core.Data.Entities.QuizQuestions", b =>
                {
                    b.HasOne("API_University_Dissertation.Core.Data.Entities.QuestionType", "QuestionType")
                        .WithMany("QuizQuestions")
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionType");
                });

            modelBuilder.Entity("API_University_Dissertation.Core.Data.Entities.QuestionType", b =>
                {
                    b.Navigation("QuizQuestions");
                });

            modelBuilder.Entity("API_University_Dissertation.Core.Data.Entities.QuizQuestions", b =>
                {
                    b.Navigation("QuestionChoices");
                });
#pragma warning restore 612, 618
        }
    }
}
