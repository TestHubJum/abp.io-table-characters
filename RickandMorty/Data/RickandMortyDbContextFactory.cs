using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RickandMorty.Data;

public class RickandMortyDbContextFactory : IDesignTimeDbContextFactory<RickandMortyDbContext>
{
    public RickandMortyDbContext CreateDbContext(string[] args)
    {
        RickandMortyEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<RickandMortyDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));

        return new RickandMortyDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
