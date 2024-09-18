using RickandMorty.Entities;
using RickandMorty.ViewModels;

namespace RickandMorty.Services.Interfaces
{
    public interface IRickAndMortyService
    {
        Task<RickAndMortyApiViewModel> GetCharactersAsync(int pageNumber=1);
    }
}
