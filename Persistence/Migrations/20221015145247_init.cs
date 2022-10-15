using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Employer = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    LinkWebsiteUrl = table.Column<string>(type: "TEXT", nullable: true),
                    LinkRepoUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SvgUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    employmentPositionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experience_Employment_employmentPositionId",
                        column: x => x.employmentPositionId,
                        principalTable: "Employment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Phonenumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    employmentReferenceId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.Id);
                    table.ForeignKey(
                        name: "FK_References_Employment_employmentReferenceId",
                        column: x => x.employmentReferenceId,
                        principalTable: "Employment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillShort",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SvgUrl = table.Column<string>(type: "TEXT", nullable: true),
                    projectFrameworkId = table.Column<Guid>(type: "TEXT", nullable: true),
                    projectLanguageId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillShort", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillShort_Project_projectFrameworkId",
                        column: x => x.projectFrameworkId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SkillShort_Project_projectLanguageId",
                        column: x => x.projectLanguageId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TextLocale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    courseId = table.Column<Guid>(type: "TEXT", nullable: true),
                    experienceHeaderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    experienceSubheaderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    experienceTextId = table.Column<Guid>(type: "TEXT", nullable: true),
                    referenceRoleId = table.Column<Guid>(type: "TEXT", nullable: true),
                    schoolId = table.Column<Guid>(type: "TEXT", nullable: true),
                    skillTextId = table.Column<Guid>(type: "TEXT", nullable: true),
                    textId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextLocale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextLocale_Experience_experienceHeaderId",
                        column: x => x.experienceHeaderId,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextLocale_Experience_experienceSubheaderId",
                        column: x => x.experienceSubheaderId,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextLocale_Experience_experienceTextId",
                        column: x => x.experienceTextId,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextLocale_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TextLocale_References_referenceRoleId",
                        column: x => x.referenceRoleId,
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextLocale_School_courseId",
                        column: x => x.courseId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextLocale_School_schoolId",
                        column: x => x.schoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextLocale_School_textId",
                        column: x => x.textId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextLocale_Skill_skillTextId",
                        column: x => x.skillTextId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experience_employmentPositionId",
                table: "Experience",
                column: "employmentPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_References_employmentReferenceId",
                table: "References",
                column: "employmentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillShort_projectFrameworkId",
                table: "SkillShort",
                column: "projectFrameworkId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillShort_projectLanguageId",
                table: "SkillShort",
                column: "projectLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TextLocale_courseId",
                table: "TextLocale",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_TextLocale_experienceHeaderId",
                table: "TextLocale",
                column: "experienceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TextLocale_experienceSubheaderId",
                table: "TextLocale",
                column: "experienceSubheaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TextLocale_experienceTextId",
                table: "TextLocale",
                column: "experienceTextId");

            migrationBuilder.CreateIndex(
                name: "IX_TextLocale_ProjectId",
                table: "TextLocale",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TextLocale_referenceRoleId",
                table: "TextLocale",
                column: "referenceRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TextLocale_schoolId",
                table: "TextLocale",
                column: "schoolId");

            migrationBuilder.CreateIndex(
                name: "IX_TextLocale_skillTextId",
                table: "TextLocale",
                column: "skillTextId");

            migrationBuilder.CreateIndex(
                name: "IX_TextLocale_textId",
                table: "TextLocale",
                column: "textId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillShort");

            migrationBuilder.DropTable(
                name: "TextLocale");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Employment");
        }
    }
}
