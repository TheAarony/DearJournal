using Microsoft.EntityFrameworkCore;
using Code.Models;//points to the folder where JournalDb.cs is

namespace Code.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<JournalDb> Journals {get;set;}
    }
}