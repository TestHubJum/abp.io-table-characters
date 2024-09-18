using RickandMorty.Localization;
using Volo.Abp.AspNetCore.Components;

namespace RickandMorty;

public abstract class RickandMortyComponentBase : AbpComponentBase
{
    protected RickandMortyComponentBase()
    {
        LocalizationResource = typeof(RickandMortyResource);
    }
}
