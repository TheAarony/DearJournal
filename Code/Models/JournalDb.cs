using System.ComponentModel.DataAnnotations;
namespace Code.Models;
using System;

public class JournalDb
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}