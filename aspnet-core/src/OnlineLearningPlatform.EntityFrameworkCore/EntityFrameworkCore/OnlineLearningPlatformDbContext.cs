using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using OnlineLearningPlatform.Authorization.Roles;
using OnlineLearningPlatform.Authorization.Users;
using OnlineLearningPlatform.MultiTenancy;

namespace OnlineLearningPlatform.EntityFrameworkCore
{
    public class OnlineLearningPlatformDbContext : AbpZeroDbContext<Tenant, Role, User, OnlineLearningPlatformDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public OnlineLearningPlatformDbContext(DbContextOptions<OnlineLearningPlatformDbContext> options)
            : base(options)
        {
        }
    }
}
