using Microsoft.EntityFrameworkCore;


namespace PromHistory.Models
{
    public class HistoryContext : DbContext
    {
        public DbSet<HistoricalEvent> History { get; set; }
        public DbSet<AddHistory> AddHistory { get; set; }
        public DbSet<Facts> Facts { get; set; }

        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddHistory>()
                .HasKey(ah => ah.Id); // Установка первичного ключа для AddHistory

            modelBuilder.Entity<AddHistory>()
                .HasOne(ah => ah.HistoricalEvent) // Связь с HistoricalEvent
                .WithMany(e => e.AddHistories) // Один HistoricalEvent может иметь много AddHistory
                .HasForeignKey(ah => ah.DateId); // Внешний ключ
        }
    }
}
