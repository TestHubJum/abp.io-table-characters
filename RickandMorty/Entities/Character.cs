using Volo.Abp.Domain.Entities;

namespace RickandMorty.Entities
{
    public class Character: Entity<Guid>
    {
        public int SelfId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; } 
        public string Gender { get; set; }
        public string Origin { get; set; } 
        public string Location { get; set; } 
        public string ImageUrl { get; set; }
        public string EpisodeUrls { get; set; } 
        public DateTime CreatedAt { get; set; } 

    }
}
