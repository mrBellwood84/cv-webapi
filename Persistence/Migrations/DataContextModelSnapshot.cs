﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Domain.Employment.Employment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Employer")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employment");
                });

            modelBuilder.Entity("Domain.Experience.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Experience");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Experience");
                });

            modelBuilder.Entity("Domain.Project.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectName")
                        .HasColumnType("TEXT");

                    b.Property<string>("RepoUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Domain.School.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("School");
                });

            modelBuilder.Entity("Domain.Shared.CourseName", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SchoolId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("CourseName");
                });

            modelBuilder.Entity("Domain.Shared.ExperienceHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EmploymentExperienceHeader")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ExperienceHeader")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExperienceHeader");

                    b.ToTable("ExperienceHeader");
                });

            modelBuilder.Entity("Domain.Shared.ExperienceSubheader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EmploymentExperienceSubheader")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ExperienceSubheader")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExperienceSubheader");

                    b.ToTable("ExperienceSubheader");
                });

            modelBuilder.Entity("Domain.Shared.ExperienceText", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EmploymentExperienceText")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ExperienceText")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExperienceText");

                    b.ToTable("ExperienceText");
                });

            modelBuilder.Entity("Domain.Shared.ProjectText", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectText");
                });

            modelBuilder.Entity("Domain.Shared.Reference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EmploymentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phonenumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmploymentId");

                    b.ToTable("Reference");
                });

            modelBuilder.Entity("Domain.Shared.ReferenceText", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ReferenceId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceId");

                    b.ToTable("ReferenceText");
                });

            modelBuilder.Entity("Domain.Shared.SchoolName", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SchoolId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("SchoolName");
                });

            modelBuilder.Entity("Domain.Shared.SchoolText", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SchoolId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("SchoolText");
                });

            modelBuilder.Entity("Domain.Shared.SkillText", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SkillId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("SkillText");
                });

            modelBuilder.Entity("Domain.Skill.FrameworkSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SvgUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("FrameworkSkill");
                });

            modelBuilder.Entity("Domain.Skill.LanguageSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SvgUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("LanguageSkill");
                });

            modelBuilder.Entity("Domain.Skill.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SvgUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("Domain.Experience.EmploymentExperience", b =>
                {
                    b.HasBaseType("Domain.Experience.Experience");

                    b.Property<Guid?>("EmploymentId")
                        .HasColumnType("TEXT");

                    b.HasIndex("EmploymentId");

                    b.HasDiscriminator().HasValue("EmploymentExperience");
                });

            modelBuilder.Entity("Domain.Shared.CourseName", b =>
                {
                    b.HasOne("Domain.School.School", null)
                        .WithMany("Course")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Shared.ExperienceHeader", b =>
                {
                    b.HasOne("Domain.Experience.Experience", null)
                        .WithMany("Header")
                        .HasForeignKey("ExperienceHeader")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Shared.ExperienceSubheader", b =>
                {
                    b.HasOne("Domain.Experience.Experience", null)
                        .WithMany("Subheader")
                        .HasForeignKey("ExperienceSubheader")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Shared.ExperienceText", b =>
                {
                    b.HasOne("Domain.Experience.Experience", null)
                        .WithMany("Text")
                        .HasForeignKey("ExperienceText")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Shared.ProjectText", b =>
                {
                    b.HasOne("Domain.Project.Project", null)
                        .WithMany("Text")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Shared.Reference", b =>
                {
                    b.HasOne("Domain.Employment.Employment", null)
                        .WithMany("References")
                        .HasForeignKey("EmploymentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Shared.ReferenceText", b =>
                {
                    b.HasOne("Domain.Shared.Reference", null)
                        .WithMany("Role")
                        .HasForeignKey("ReferenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Shared.SchoolName", b =>
                {
                    b.HasOne("Domain.School.School", null)
                        .WithMany("SchoolName")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Shared.SchoolText", b =>
                {
                    b.HasOne("Domain.School.School", null)
                        .WithMany("Text")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Shared.SkillText", b =>
                {
                    b.HasOne("Domain.Skill.Skill", null)
                        .WithMany("Text")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Skill.FrameworkSkill", b =>
                {
                    b.HasOne("Domain.Project.Project", null)
                        .WithMany("Frameworks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Skill.LanguageSkill", b =>
                {
                    b.HasOne("Domain.Project.Project", null)
                        .WithMany("Languages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Experience.EmploymentExperience", b =>
                {
                    b.HasOne("Domain.Employment.Employment", null)
                        .WithMany("Positions")
                        .HasForeignKey("EmploymentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Employment.Employment", b =>
                {
                    b.Navigation("Positions");

                    b.Navigation("References");
                });

            modelBuilder.Entity("Domain.Experience.Experience", b =>
                {
                    b.Navigation("Header");

                    b.Navigation("Subheader");

                    b.Navigation("Text");
                });

            modelBuilder.Entity("Domain.Project.Project", b =>
                {
                    b.Navigation("Frameworks");

                    b.Navigation("Languages");

                    b.Navigation("Text");
                });

            modelBuilder.Entity("Domain.School.School", b =>
                {
                    b.Navigation("Course");

                    b.Navigation("SchoolName");

                    b.Navigation("Text");
                });

            modelBuilder.Entity("Domain.Shared.Reference", b =>
                {
                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Skill.Skill", b =>
                {
                    b.Navigation("Text");
                });
#pragma warning restore 612, 618
        }
    }
}
