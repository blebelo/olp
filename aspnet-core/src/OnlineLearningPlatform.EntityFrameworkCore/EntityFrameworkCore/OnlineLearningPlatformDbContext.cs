using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineLearningPlatform.Authorization.Roles;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.MultiTenancy;
using OnlineLearningPlatform.Domain.Students;
using System;
using System.Linq;

namespace OnlineLearningPlatform.EntityFrameworkCore
{
    public class OnlineLearningPlatformDbContext : AbpZeroDbContext<Tenant, Role, User, OnlineLearningPlatformDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public OnlineLearningPlatformDbContext(DbContextOptions<OnlineLearningPlatformDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),           // Convert to UTC when saving
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)); // Specify UTC kind when reading

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
