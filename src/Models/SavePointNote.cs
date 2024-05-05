namespace SavePointAPI.Models
{
    public class SavePointNote
    {
        public int SavePointNoteId { get; set; }
        public string? Note { get; set; }
        public DateOnly NoteDate { get; set; }
        public required SavePointGame SavePointGameId { get; set; }
    }
}