namespace Code.Models;

public class JournalDb
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
}