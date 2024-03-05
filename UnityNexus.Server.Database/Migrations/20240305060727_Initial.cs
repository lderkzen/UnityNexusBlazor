using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UnityNexus.Server.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "answer_types",
                columns: table => new
                {
                    answer_type_id = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answer_types", x => x.answer_type_id);
                });

            migrationBuilder.CreateTable(
                name: "category_types",
                columns: table => new
                {
                    category_type_id = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_types", x => x.category_type_id);
                });

            migrationBuilder.CreateTable(
                name: "group_types",
                columns: table => new
                {
                    group_type_id = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_types", x => x.group_type_id);
                });

            migrationBuilder.CreateTable(
                name: "submission_statusses",
                columns: table => new
                {
                    submission_status_id = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_submission_statusses", x => x.submission_status_id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.tag_id);
                });

            migrationBuilder.CreateTable(
                name: "user_notification_settings",
                columns: table => new
                {
                    user_notification_settings_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    notification_flag_sum = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_notification_settings", x => x.user_notification_settings_id);
                });

            migrationBuilder.CreateTable(
                name: "visibility_levels",
                columns: table => new
                {
                    visibility_level_id = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visibility_levels", x => x.visibility_level_id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_type_id = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                    table.ForeignKey(
                        name: "FK_categories_category_types_category_type_id",
                        column: x => x.category_type_id,
                        principalTable: "category_types",
                        principalColumn: "category_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_type_id = table.Column<byte>(type: "smallint", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: true),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: true),
                    channel_id = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    intro = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    locked = table.Column<bool>(type: "boolean", nullable: false),
                    position = table.Column<short>(type: "smallint", nullable: false),
                    logo_path = table.Column<string>(type: "text", nullable: true),
                    banner_path = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.group_id);
                    table.ForeignKey(
                        name: "FK_groups_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "FK_groups_group_types_group_type_id",
                        column: x => x.group_type_id,
                        principalTable: "group_types",
                        principalColumn: "group_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "forms",
                columns: table => new
                {
                    form_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_id = table.Column<int>(type: "integer", nullable: true),
                    topic = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forms", x => x.form_id);
                    table.ForeignKey(
                        name: "FK_forms_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "group_id");
                });

            migrationBuilder.CreateTable(
                name: "GroupTag",
                columns: table => new
                {
                    GroupsGroupId = table.Column<int>(type: "integer", nullable: false),
                    TagsTagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTag", x => new { x.GroupsGroupId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_GroupTag_groups_GroupsGroupId",
                        column: x => x.GroupsGroupId,
                        principalTable: "groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTag_tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "tags",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    question_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    form_id = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    answer_type_id = table.Column<byte>(type: "smallint", nullable: false),
                    required = table.Column<bool>(type: "boolean", nullable: false),
                    position = table.Column<short>(type: "smallint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.question_id);
                    table.ForeignKey(
                        name: "FK_questions_answer_types_answer_type_id",
                        column: x => x.answer_type_id,
                        principalTable: "answer_types",
                        principalColumn: "answer_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_questions_forms_form_id",
                        column: x => x.form_id,
                        principalTable: "forms",
                        principalColumn: "form_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "submission",
                columns: table => new
                {
                    submission_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    form_id = table.Column<int>(type: "integer", nullable: false),
                    applicant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    submission_status_id = table.Column<byte>(type: "smallint", nullable: false),
                    visibility_level_id = table.Column<byte>(type: "smallint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_submission", x => x.submission_id);
                    table.ForeignKey(
                        name: "FK_submission_forms_form_id",
                        column: x => x.form_id,
                        principalTable: "forms",
                        principalColumn: "form_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_submission_submission_statusses_submission_status_id",
                        column: x => x.submission_status_id,
                        principalTable: "submission_statusses",
                        principalColumn: "submission_status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_submission_visibility_levels_visibility_level_id",
                        column: x => x.visibility_level_id,
                        principalTable: "visibility_levels",
                        principalColumn: "visibility_level_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    answer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    previous_answer_id = table.Column<int>(type: "integer", nullable: true),
                    question_id = table.Column<int>(type: "integer", nullable: false),
                    submission_id = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answers", x => x.answer_id);
                    table.ForeignKey(
                        name: "FK_answers_answers_previous_answer_id",
                        column: x => x.previous_answer_id,
                        principalTable: "answers",
                        principalColumn: "answer_id");
                    table.ForeignKey(
                        name: "FK_answers_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_answers_submission_submission_id",
                        column: x => x.submission_id,
                        principalTable: "submission",
                        principalColumn: "submission_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "answer_types",
                columns: new[] { "answer_type_id", "name", "position" },
                values: new object[,]
                {
                    { (byte)0, "Unspecified", (short)0 },
                    { (byte)1, "String", (short)1 },
                    { (byte)2, "Text", (short)2 },
                    { (byte)3, "Numeric", (short)3 },
                    { (byte)4, "Boolean", (short)4 },
                    { (byte)5, "OneIdentifier", (short)5 },
                    { (byte)6, "MultiIdentifier", (short)6 }
                });

            migrationBuilder.InsertData(
                table: "category_types",
                columns: new[] { "category_type_id", "name", "position" },
                values: new object[,]
                {
                    { (byte)0, "Undefined", (short)0 },
                    { (byte)1, "Generic", (short)1 },
                    { (byte)2, "Chapter", (short)2 }
                });

            migrationBuilder.InsertData(
                table: "group_types",
                columns: new[] { "group_type_id", "name", "position" },
                values: new object[,]
                {
                    { (byte)0, "Unspecified", (short)0 },
                    { (byte)1, "Closed", (short)1 },
                    { (byte)2, "Open", (short)2 }
                });

            migrationBuilder.InsertData(
                table: "submission_statusses",
                columns: new[] { "submission_status_id", "name", "position" },
                values: new object[,]
                {
                    { (byte)0, "Unknown", (short)0 },
                    { (byte)1, "Created", (short)1 },
                    { (byte)2, "Submitted", (short)2 },
                    { (byte)3, "Revised", (short)3 },
                    { (byte)4, "Suspended", (short)4 },
                    { (byte)5, "Closed", (short)5 }
                });

            migrationBuilder.InsertData(
                table: "visibility_levels",
                columns: new[] { "visibility_level_id", "name", "position" },
                values: new object[,]
                {
                    { (byte)0, "Unconfigured", (short)0 },
                    { (byte)1, "Private", (short)1 },
                    { (byte)2, "Public", (short)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_answers_previous_answer_id",
                table: "answers",
                column: "previous_answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_answers_question_id",
                table: "answers",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_answers_submission_id",
                table: "answers",
                column: "submission_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_category_type_id",
                table: "categories",
                column: "category_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_forms_group_id",
                table: "forms",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_category_id",
                table: "groups",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_group_type_id",
                table: "groups",
                column: "group_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_position",
                table: "groups",
                column: "position");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTag_TagsTagId",
                table: "GroupTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_answer_type_id",
                table: "questions",
                column: "answer_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_questions_form_id_position",
                table: "questions",
                columns: new[] { "form_id", "position" });

            migrationBuilder.CreateIndex(
                name: "IX_submission_applicant_id",
                table: "submission",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_submission_form_id",
                table: "submission",
                column: "form_id");

            migrationBuilder.CreateIndex(
                name: "IX_submission_submission_status_id",
                table: "submission",
                column: "submission_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_submission_visibility_level_id",
                table: "submission",
                column: "visibility_level_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "GroupTag");

            migrationBuilder.DropTable(
                name: "user_notification_settings");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "submission");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "answer_types");

            migrationBuilder.DropTable(
                name: "forms");

            migrationBuilder.DropTable(
                name: "submission_statusses");

            migrationBuilder.DropTable(
                name: "visibility_levels");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "group_types");

            migrationBuilder.DropTable(
                name: "category_types");
        }
    }
}
