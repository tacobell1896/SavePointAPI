using SavePointAPI.Models;

public class SavePointNoteDTO
{
    public int SavePointNoteId { get; set; }
    public string? Note { get; set; }
    public DateOnly NoteDate { get; set; }
    public required SavePointGame SavePointGame { get; set; }
}