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
            DotNetEnv.Env.Load();

            var builder = new DbContextOptionsBuilder<OnlineLearningPlatformDbContext>();
            var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            OnlineLearningPlatformDbContextConfigurer.Configure(builder, connectionString);

            return new OnlineLearningPlatformDbContext(builder.Options);
        }
    }
}
