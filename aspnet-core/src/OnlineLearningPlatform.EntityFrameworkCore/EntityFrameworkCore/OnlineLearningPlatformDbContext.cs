using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineLearningPlatform.Authorization.Roles;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.MultiTenancy;
using System;
using System.Linq;

namespace OnlineLearningPlatform.EntityFrameworkCore
{
    public class OnlineLearningPlatformDbContext : AbpZeroDbContext<Tenant, Role, User, OnlineLearningPlatformDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public OnlineLearningPlatformDbContext(DbContextOptions<OnlineLearningPlatformDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Instructor>()
                .HasIndex("UserAccountId")
                .IsUnique();

        }
    }
}
