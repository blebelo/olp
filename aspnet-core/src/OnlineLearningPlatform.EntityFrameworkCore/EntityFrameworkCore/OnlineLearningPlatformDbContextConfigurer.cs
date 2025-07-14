using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace OnlineLearningPlatform.EntityFrameworkCore
{
    public static class OnlineLearningPlatformDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<OnlineLearningPlatformDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<OnlineLearningPlatformDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
