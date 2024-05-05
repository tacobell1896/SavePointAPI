using Microsoft.EntityFrameworkCore;

namespace SavePointAPI.Models
{
    public class SavePointContext : DbContext
    {
        public SavePointContext(DbContextOptions<SavePointContext> options)
            : base(options)
        {
        }

        public DbSet<SavePointNote> SavePointNotes { get; set; }
        public DbSet<SavePointGame> SavePointGames { get; set; }
    }
}