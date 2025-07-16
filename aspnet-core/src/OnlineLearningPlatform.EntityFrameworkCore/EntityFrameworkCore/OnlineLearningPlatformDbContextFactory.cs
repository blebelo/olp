using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnlineLearningPlatform.Configuration;
using OnlineLearningPlatform.Web;
using System;

namespace OnlineLearningPlatform.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class OnlineLearningPlatformDbContextFactory : IDesignTimeDbContextFactory<OnlineLearningPlatformDbContext>
    {
        public OnlineLearningPlatformDbContext CreateDbContext(string[] args)
        {
            var currentEnv = DotNetEnv.Env.Load(".env"); 

            var builder = new DbContextOptionsBuilder<OnlineLearningPlatformDbContext>();

            var connection = new Npgsql.NpgsqlConnectionStringBuilder
            {
                Host = Environment.GetEnvironmentVariable("PGHOST"),
                Port = int.Parse(Environment.GetEnvironmentVariable("PGPORT") ?? "5432"),
                Username = Environment.GetEnvironmentVariable("PGUSER"),
                Password = Environment.GetEnvironmentVariable("PGPASSWORD"),
                Database = Environment.GetEnvironmentVariable("PGDATABASE")
            };

            var connectionString = connection.ConnectionString;

            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            OnlineLearningPlatformDbContextConfigurer.Configure(builder, connectionString);

            return new OnlineLearningPlatformDbContext(builder.Options);
        }
    }
}
