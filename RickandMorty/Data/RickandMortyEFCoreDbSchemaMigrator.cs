using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace RickandMorty.Data;

public class RickandMortyEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public RickandMortyEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the RickandMortyDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<RickandMortyDbContext>()
            .Database
            .MigrateAsync();
    }
}
