
using RickandMorty.Entities;
using RickandMorty.Services.Interfaces;
using RickandMorty.ViewModels;
using System.Text.Json;
using Volo.Abp.Domain.Repositories;

namespace RickandMorty.Services
{
    public class RickAndMortyService : IRickAndMortyService
    {
        private readonly HttpClient _httpClient;
        private readonly IRepository<Character, Guid> _characterRepository;

        public RickAndMortyService(HttpClient httpClient, IRepository<Character, Guid> characterRepository)
        {
            _httpClient = httpClient;
            _characterRepository = characterRepository;
        }

        public async Task<RickAndMortyApiViewModel> GetCharactersAsync(int pageNumber = 1)
        {
            List<Character> characters = new List<Character>();
            RickAndMortyApiViewModel viewModel = new RickAndMortyApiViewModel();
            
            try
            {
                
                var response = await _httpClient.GetStringAsync($"https://rickandmortyapi.com/api/character?page={pageNumber}");


                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var charactersData = JsonSerializer.Deserialize<RickAndMortyApiResponse>(response, options);
                

                characters = charactersData.Results.Select(c => new Character
                {
                    SelfId = c.Id,
                    Name = c.Name ?? "Unknown", 
                    Status = c.Status ?? "Unknown",
                    Species = c.Species ?? "Unknown",
                    Type = c.Type ?? string.Empty,
                    Gender = c.Gender ?? "Unknown",
                    Origin = c.Origin?.Name ?? "Unknown",
                    Location = c.Location?.Name ?? "Unknown",
                    ImageUrl = c.Image ?? string.Empty,
                    EpisodeUrls = c.Episode != null ? string.Join(",", c.Episode) : string.Empty,
                    CreatedAt = DateTime.TryParse(c.Created, out var createdAt) ? createdAt : DateTime.MinValue
                }).ToList();

                viewModel.characters = characters;
                viewModel.Info = charactersData.Info;
                


                try
                {
                    foreach (var character in characters)
                    {
                        var existingCharacter = await _characterRepository.FindAsync(c => c.SelfId == character.SelfId);
                        if (existingCharacter == null)
                        {
                            await _characterRepository.InsertAsync(character, true);

                        }
                    }
                }
                catch (Exception ex) { await Console.Out.WriteLineAsync($"Сообщение из базы: {ex.Message}"); }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Ошибка при запросе к API: {ex.Message}");
                int countPage = 20;
                characters = await _characterRepository.GetListAsync(c => c.SelfId >= pageNumber* countPage && c.SelfId <= pageNumber+1 * countPage);
                viewModel.characters = characters;
                viewModel.Info = new Info() { Count = (int)await _characterRepository.GetCountAsync(), Pages = (int)await _characterRepository.GetCountAsync() / 20};
                

            }


           return viewModel;
        }
    }

    


}
