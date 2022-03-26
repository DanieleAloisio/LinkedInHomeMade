using Data_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitae { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<LogGitHub> LogGitHub { get; set; }
        public DbSet<Fans> Fans { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Skills)
                .WithMany(x => x.Users)
                .UsingEntity(x => x.ToTable("Rel_Skills_ApplicationUsers"));


            modelBuilder.Entity<Fans>()
                .HasKey(e => new { e.FollowUserId, e.FanUserId });

            modelBuilder.Entity<Fans>()
                .HasOne(e => e.FollowUser)
                .WithMany(e => e.Follow).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.FollowUserId);

            modelBuilder.Entity<Fans>()
                .HasOne(e => e.FanUser)
                .WithMany(e => e.Fan).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.FanUserId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
