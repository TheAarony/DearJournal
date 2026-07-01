using System.ComponentModel.DataAnnotations;
namespace Code.Models;

public class JournalDb
{
    public int Id { get; set; }
    [ Required ]
    public string Title { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
}