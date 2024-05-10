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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SavePointGame>()
                .HasMany(g => g.SavePointNotes)
                .WithOne(n => n.SavePointGame!)
                .HasForeignKey(n => n.SavePointGameId);

            modelBuilder.Entity<SavePointNote>()
                .HasOne(n => n.SavePointGame)
                .WithMany(g => g.SavePointNotes!)
                .HasForeignKey(n => n.SavePointGameId);
        }
    }
}