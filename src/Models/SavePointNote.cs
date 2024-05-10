namespace SavePointAPI.Models
{
    public class SavePointNote
    {
        public int SavePointNoteId { get; set; }
        public string? Note { get; set; }
        public DateOnly NoteDate { get; set; }
        public int SavePointGameId { get; set; }
        public SavePointGame? SavePointGame { get; set; }
    }
}