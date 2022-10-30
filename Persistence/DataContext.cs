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
            builder.Entity<Employment>()
                .HasMany(e => e.Positions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Employment>()
                .HasMany(e => e.References)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<EmploymentExperience>()
                .HasMany(e => e.Header)
                .WithOne()
                .HasForeignKey("EmploymentExperienceHeader")
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<EmploymentExperience>()
                .HasMany(e => e.Subheader)
                .WithOne()
                .HasForeignKey("EmploymentExperienceSubheader")
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<EmploymentExperience>()
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

            builder.Entity<Project>()
                .HasMany(e => e.Languages)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Project>()
                .HasMany(e => e.Frameworks)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Project>()
                .HasMany(e => e.Text)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Reference>()
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

        public DbSet<Employment> Employment { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Skill> Skill { get; set; }
    }
} 