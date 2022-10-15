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
            builder.Entity<School>()
                .HasMany(x => x.SchoolName)
                .WithOne()
                .HasForeignKey("schoolId")
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<School>()
                .HasMany(x => x.Course)
                .WithOne()
                .HasForeignKey("courseId")
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<School>()
                .HasMany(x => x.Text)
                .WithOne()
                .HasForeignKey("textId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Experience>()
                .HasMany(e => e.Header)
                .WithOne()
                .HasForeignKey("experienceHeaderId")
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Experience>()
                .HasMany(e => e.Subheader)
                .WithOne()
                .HasForeignKey("experienceSubheaderId")
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Experience>()
                .HasMany(e => e.Text)
                .WithOne()
                .HasForeignKey("experienceTextId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Reference>()
                .HasMany(r => r.Role)
                .WithOne()
                .HasForeignKey("referenceRoleId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Employment>()
                .HasMany(e => e.Positions)
                .WithOne()
                .HasForeignKey("employmentPositionId")
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Employment>()
                .HasMany(e => e.References)
                .WithOne()
                .HasForeignKey("employmentReferenceId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Skill>()
                .HasMany(x => x.Text)
                .WithOne()
                .HasForeignKey("skillTextId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Project>()
                .HasMany(x => x.Frameworks)
                .WithOne()
                .HasForeignKey("projectFrameworkId")
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Project>()
                .HasMany(x => x.Languages)
                .WithOne()
                .HasForeignKey("projectLanguageId")
                .OnDelete(DeleteBehavior.NoAction);


        }

        public DbSet<Employment> Employment { get; set; }

        public DbSet<Experience> Experience { get; set; }

        public DbSet<School> School { set; get; }

        public DbSet<Skill> Skill { set; get; }

        public DbSet<Project> Project { get; set; }

        private DbSet<Reference> References { get; set; }
    
    }
}