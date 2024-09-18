using Microsoft.Extensions.Localization;
using RickandMorty.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace RickandMorty;

[Dependency(ReplaceServices = true)]
public class RickandMortyBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<RickandMortyResource> _localizer;

    public RickandMortyBrandingProvider(IStringLocalizer<RickandMortyResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
