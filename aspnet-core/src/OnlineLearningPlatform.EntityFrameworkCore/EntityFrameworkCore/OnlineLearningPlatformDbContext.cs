using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineLearningPlatform.Authorization.Roles;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Entities;
using OnlineLearningPlatform.Domain.Instructors;
using OnlineLearningPlatform.MultiTenancy;
using System;
using System.Linq;

namespace OnlineLearningPlatform.EntityFrameworkCore
{
    public class OnlineLearningPlatformDbContext : AbpZeroDbContext<Tenant, Role, User, OnlineLearningPlatformDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public OnlineLearningPlatformDbContext(DbContextOptions<OnlineLearningPlatformDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime));

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name).Property(property.Name)
                        .HasConversion(dateTimeConverter);
                }
            }
        }
    }
}
