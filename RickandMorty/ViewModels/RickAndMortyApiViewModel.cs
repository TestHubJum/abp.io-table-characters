using RickandMorty.Entities;

namespace RickandMorty.ViewModels
{
    public class RickAndMortyApiViewModel
    {
        public Info Info { get; set; }
        public List<Character> characters { get; set; }
    }

    public class RickAndMortyApiResponse
    {
        public Info Info { get; set; }
        public List<ApiCharacter> Results { get; set; }
    }

    public class Info
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }


    }

    public class ApiCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Status { get; set; }
        public string? Species { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public ApiOrigin? Origin { get; set; }
        public ApiLocation? Location { get; set; }
        public string? Image { get; set; }
        public List<string>? Episode { get; set; }
        public string url { get; set; }
        public string? Created { get; set; }
    }
    public class ApiOrigin
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class ApiLocation
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
