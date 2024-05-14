namespace SavePointAPI.Models
{
    public class SavePointGame
    {
        public int SavePointGameId { get; set; }
        public int OwnerId { get; set; }
        public string? GameName { get; set; }
        public string? GameConsole { get; set; }
        public string? GameGenre { get; set; }
        public string? GameDeveloper { get; set; }
        public string? GamePublisher { get; set; }
        public string? GameReleaseDate { get; set; }
        public string? GameDescription { get; set; }
        public string? GameRating { get; set; }
        public string? GameImage { get; set; }
        public ICollection<SavePointNote>? SavePointNotes { get; }
    }
}