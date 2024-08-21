using PromHistory.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromHistory.Models
{
    public class AddHistory
    {
        public int Id { get; set; } // Это поле должно быть автоинкрементируемым в БД
        public string Description { get; set; }

        [ForeignKey("HistoricalEvent")]
        public int DateId { get; set; } // Внешний ключ для связи с HistoricalEvent

        public virtual HistoricalEvent HistoricalEvent { get; set; } // Изменено на HistoricalEvent вместо HistoricalEventId
    }
}


