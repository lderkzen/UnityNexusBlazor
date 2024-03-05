﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UnityNexus.Server.Database;

#nullable disable

namespace UnityNexus.Server.Database.Migrations
{
    [DbContext(typeof(UnityNexusContext))]
    [Migration("20240305060727_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GroupTag", b =>
                {
                    b.Property<int>("GroupsGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("TagsTagId")
                        .HasColumnType("integer");

                    b.HasKey("GroupsGroupId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("GroupTag");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("answer_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnswerId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("PreviousAnswerId")
                        .HasColumnType("integer")
                        .HasColumnName("previous_answer_id");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer")
                        .HasColumnName("question_id");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("integer")
                        .HasColumnName("submission_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("AnswerId");

                    b.HasIndex("PreviousAnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SubmissionId");

                    b.ToTable("answers");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.AnswerType", b =>
                {
                    b.Property<byte>("AnswerTypeId")
                        .HasColumnType("smallint")
                        .HasColumnName("answer_type_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<short>("Position")
                        .HasColumnType("smallint")
                        .HasColumnName("position");

                    b.HasKey("AnswerTypeId");

                    b.ToTable("answer_types");

                    b.HasData(
                        new
                        {
                            AnswerTypeId = (byte)0,
                            Name = "Unspecified",
                            Position = (short)0
                        },
                        new
                        {
                            AnswerTypeId = (byte)1,
                            Name = "String",
                            Position = (short)1
                        },
                        new
                        {
                            AnswerTypeId = (byte)2,
                            Name = "Text",
                            Position = (short)2
                        },
                        new
                        {
                            AnswerTypeId = (byte)3,
                            Name = "Numeric",
                            Position = (short)3
                        },
                        new
                        {
                            AnswerTypeId = (byte)4,
                            Name = "Boolean",
                            Position = (short)4
                        },
                        new
                        {
                            AnswerTypeId = (byte)5,
                            Name = "OneIdentifier",
                            Position = (short)5
                        },
                        new
                        {
                            AnswerTypeId = (byte)6,
                            Name = "MultiIdentifier",
                            Position = (short)6
                        });
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<byte>("CategoryTypeId")
                        .HasColumnType("smallint")
                        .HasColumnName("category_type_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryTypeId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.CategoryType", b =>
                {
                    b.Property<byte>("CategoryTypeId")
                        .HasColumnType("smallint")
                        .HasColumnName("category_type_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<short>("Position")
                        .HasColumnType("smallint")
                        .HasColumnName("position");

                    b.HasKey("CategoryTypeId");

                    b.ToTable("category_types");

                    b.HasData(
                        new
                        {
                            CategoryTypeId = (byte)0,
                            Name = "Undefined",
                            Position = (short)0
                        },
                        new
                        {
                            CategoryTypeId = (byte)1,
                            Name = "Generic",
                            Position = (short)1
                        },
                        new
                        {
                            CategoryTypeId = (byte)2,
                            Name = "Chapter",
                            Position = (short)2
                        });
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Form", b =>
                {
                    b.Property<int>("FormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("form_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FormId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("topic");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("FormId");

                    b.HasIndex("GroupId");

                    b.ToTable("forms");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GroupId"));

                    b.Property<string>("BannerPath")
                        .HasColumnType("text")
                        .HasColumnName("banner_path");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("ChannelId")
                        .HasColumnType("text")
                        .HasColumnName("channel_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<byte>("GroupTypeId")
                        .HasColumnType("smallint")
                        .HasColumnName("group_type_id");

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("intro");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("boolean")
                        .HasColumnName("locked");

                    b.Property<string>("LogoPath")
                        .HasColumnType("text")
                        .HasColumnName("logo_path");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<short>("Position")
                        .HasColumnType("smallint")
                        .HasColumnName("position");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("GroupId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GroupTypeId");

                    b.HasIndex("Position");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.GroupType", b =>
                {
                    b.Property<byte>("GroupTypeId")
                        .HasColumnType("smallint")
                        .HasColumnName("group_type_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<short>("Position")
                        .HasColumnType("smallint")
                        .HasColumnName("position");

                    b.HasKey("GroupTypeId");

                    b.ToTable("group_types");

                    b.HasData(
                        new
                        {
                            GroupTypeId = (byte)0,
                            Name = "Unspecified",
                            Position = (short)0
                        },
                        new
                        {
                            GroupTypeId = (byte)1,
                            Name = "Closed",
                            Position = (short)1
                        },
                        new
                        {
                            GroupTypeId = (byte)2,
                            Name = "Open",
                            Position = (short)2
                        });
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("question_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionId"));

                    b.Property<byte>("AnswerTypeId")
                        .HasColumnType("smallint")
                        .HasColumnName("answer_type_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<int>("FormId")
                        .HasColumnType("integer")
                        .HasColumnName("form_id");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean")
                        .HasColumnName("required");

                    b.Property<short>("Position")
                        .HasColumnType("smallint")
                        .HasColumnName("position");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("QuestionId");

                    b.HasIndex("AnswerTypeId");

                    b.HasIndex("FormId", "Position");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Submission", b =>
                {
                    b.Property<int>("SubmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("submission_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubmissionId"));

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uuid")
                        .HasColumnName("applicant_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<int>("FormId")
                        .HasColumnType("integer")
                        .HasColumnName("form_id");

                    b.Property<byte>("SubmissionStatusId")
                        .HasColumnType("smallint")
                        .HasColumnName("submission_status_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<byte>("VisibilityLevelId")
                        .HasColumnType("smallint")
                        .HasColumnName("visibility_level_id");

                    b.HasKey("SubmissionId");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("FormId");

                    b.HasIndex("SubmissionStatusId");

                    b.HasIndex("VisibilityLevelId");

                    b.ToTable("submission");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.SubmissionStatus", b =>
                {
                    b.Property<byte>("SubmissionStatusId")
                        .HasColumnType("smallint")
                        .HasColumnName("submission_status_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<short>("Position")
                        .HasColumnType("smallint")
                        .HasColumnName("position");

                    b.HasKey("SubmissionStatusId");

                    b.ToTable("submission_statusses");

                    b.HasData(
                        new
                        {
                            SubmissionStatusId = (byte)0,
                            Name = "Unknown",
                            Position = (short)0
                        },
                        new
                        {
                            SubmissionStatusId = (byte)1,
                            Name = "Created",
                            Position = (short)1
                        },
                        new
                        {
                            SubmissionStatusId = (byte)2,
                            Name = "Submitted",
                            Position = (short)2
                        },
                        new
                        {
                            SubmissionStatusId = (byte)3,
                            Name = "Revised",
                            Position = (short)3
                        },
                        new
                        {
                            SubmissionStatusId = (byte)4,
                            Name = "Suspended",
                            Position = (short)4
                        },
                        new
                        {
                            SubmissionStatusId = (byte)5,
                            Name = "Closed",
                            Position = (short)5
                        });
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("tag_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TagId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("content");

                    b.HasKey("TagId");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.UserNotificationSettings", b =>
                {
                    b.Property<int>("UserNotificationSettingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_notification_settings_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserNotificationSettingsId"));

                    b.Property<int>("NotificationFlagSum")
                        .HasColumnType("integer")
                        .HasColumnName("notification_flag_sum");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("UserNotificationSettingsId");

                    b.ToTable("user_notification_settings");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.VisibilityLevel", b =>
                {
                    b.Property<byte>("VisibilityLevelId")
                        .HasColumnType("smallint")
                        .HasColumnName("visibility_level_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<short>("Position")
                        .HasColumnType("smallint")
                        .HasColumnName("position");

                    b.HasKey("VisibilityLevelId");

                    b.ToTable("visibility_levels");

                    b.HasData(
                        new
                        {
                            VisibilityLevelId = (byte)0,
                            Name = "Unconfigured",
                            Position = (short)0
                        },
                        new
                        {
                            VisibilityLevelId = (byte)1,
                            Name = "Private",
                            Position = (short)1
                        },
                        new
                        {
                            VisibilityLevelId = (byte)2,
                            Name = "Public",
                            Position = (short)2
                        });
                });

            modelBuilder.Entity("GroupTag", b =>
                {
                    b.HasOne("UnityNexus.Server.Shared.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnityNexus.Server.Shared.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Answer", b =>
                {
                    b.HasOne("UnityNexus.Server.Shared.Models.Answer", "PreviousAnswer")
                        .WithMany()
                        .HasForeignKey("PreviousAnswerId");

                    b.HasOne("UnityNexus.Server.Shared.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnityNexus.Server.Shared.Models.Submission", "Submission")
                        .WithMany("Answers")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreviousAnswer");

                    b.Navigation("Question");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Category", b =>
                {
                    b.HasOne("UnityNexus.Server.Shared.Models.CategoryType", "CategoryType")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryType");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Form", b =>
                {
                    b.HasOne("UnityNexus.Server.Shared.Models.Group", "Group")
                        .WithMany("Forms")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Group", b =>
                {
                    b.HasOne("UnityNexus.Server.Shared.Models.Category", "Category")
                        .WithMany("Groups")
                        .HasForeignKey("CategoryId");

                    b.HasOne("UnityNexus.Server.Shared.Models.GroupType", "GroupType")
                        .WithMany("Groups")
                        .HasForeignKey("GroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("GroupType");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Question", b =>
                {
                    b.HasOne("UnityNexus.Server.Shared.Models.AnswerType", "AnswerType")
                        .WithMany("Questions")
                        .HasForeignKey("AnswerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnityNexus.Server.Shared.Models.Form", "Form")
                        .WithMany("Questions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnswerType");

                    b.Navigation("Form");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Submission", b =>
                {
                    b.HasOne("UnityNexus.Server.Shared.Models.Form", "Form")
                        .WithMany("Submissions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnityNexus.Server.Shared.Models.SubmissionStatus", "SubmissionStatus")
                        .WithMany("Submissions")
                        .HasForeignKey("SubmissionStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnityNexus.Server.Shared.Models.VisibilityLevel", "VisibilityLevel")
                        .WithMany("Submissions")
                        .HasForeignKey("VisibilityLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("SubmissionStatus");

                    b.Navigation("VisibilityLevel");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.AnswerType", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Category", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.CategoryType", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Form", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Group", b =>
                {
                    b.Navigation("Forms");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.GroupType", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.Submission", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.SubmissionStatus", b =>
                {
                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("UnityNexus.Server.Shared.Models.VisibilityLevel", b =>
                {
                    b.Navigation("Submissions");
                });
#pragma warning restore 612, 618
        }
    }
}