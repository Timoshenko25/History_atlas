namespace PromHistory.Models
{
    public class HistoricalEvent
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Date { get; set; }
            public string Description { get; set; }
       
        public virtual ICollection<AddHistory> AddHistories { get; set; } // Изменено на ICollection
        }
    }


