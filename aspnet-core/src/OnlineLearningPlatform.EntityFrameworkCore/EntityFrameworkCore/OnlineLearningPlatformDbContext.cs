using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineLearningPlatform.Authorization.Roles;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Student;
using OnlineLearningPlatform.Domain.Instructors;
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
        public DbSet<Student> Students { get; set; }

        public OnlineLearningPlatformDbContext(DbContextOptions<OnlineLearningPlatformDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Student>()
                .HasOne(s => s.UserAccount)
                .WithOne()
                .HasForeignKey<Student>("UserId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .Property(c => c.EnrolledStudents)
                .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}
