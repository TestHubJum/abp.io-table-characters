using RickandMorty.Localization;
using Volo.Abp.Application.Services;

namespace RickandMorty.Services;

/* Inherit your application services from this class. */
public abstract class RickandMortyAppService : ApplicationService
{
    protected RickandMortyAppService()
    {
        LocalizationResource = typeof(RickandMortyResource);
    }
}