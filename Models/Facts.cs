namespace PromHistory.Models
{
    public class Facts
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } // Добавлено свойство для хранения ссылки на изображение
    }
}

