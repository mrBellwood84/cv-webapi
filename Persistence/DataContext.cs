using Domain.Employment;
using Domain.Experience;
using Domain.Project;
using Domain.School;
using Domain.Shared;
using Domain.Skill;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _config;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseSqlite(_config.GetConnectionString("default"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<PositionEntity>()
                .HasMany(e => e.Header)
                .WithOne()
                .HasForeignKey("EmploymentExperienceHeader")
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<PositionEntity>()
                .HasMany(e => e.Text)
                .WithOne()
                .HasForeignKey("EmploymentExperienceText")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Experience>()
                .HasMany(e => e.Header)
                .WithOne()
                .HasForeignKey("ExperienceHeader")
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Experience>()
                .HasMany(e => e.Subheader)
                .WithOne()
                .HasForeignKey("ExperienceSubheader")
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Experience>()
                .HasMany(e => e.Text)
                .WithOne()
                .HasForeignKey("ExperienceText")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProjectEntity>()
                .HasMany(e => e.Text)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ReferenceEntity>()
                .HasMany(e => e.Role)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<School>()
                .HasMany(e => e.SchoolName)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<School>()
                .HasMany(e => e.Course)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<School>()
                .HasMany(e => e.Text)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Skill>()
                .HasMany(e => e.Text)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

                
        }

        public DbSet<EmploymentEntity> Employment { get; set; }
        public DbSet<PositionEntity> Position { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<ProjectEntity> Project { get; set; }
        public DbSet<ReferenceEntity> Reference { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Skill> Skill { get; set; }

        public DbSet<LanguageSkillEntity> LanguageSkill { get; set; }
        public DbSet<FrameworkSkillEntity> FrameworkSkill { get; set; }
    }
} 