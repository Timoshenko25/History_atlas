using HeyRed.MarkdownSharp;
using Microsoft.AspNetCore.Mvc;
using PromHistory.Models;

namespace PromHistory.Controllers
{
    public class HistoricalEventsController : Controller
    {
        private readonly HistoryContext _bd;
        public HistoricalEventsController(HistoryContext bd)
        {
            _bd = bd; 
        }
        public IActionResult Index()
        {
            var history = _bd.History.ToList();
            return View(history);
        }
        public ActionResult Search(string searchTerm)
        {
            // Приводим строку к нижнему регистру и разбиваем на слова
            var lowerSearchTerm = searchTerm.ToLower();
            var searchTerms = lowerSearchTerm.Split(' ');

            // Извлекаем данные из базы данных и фильтруем их в памяти
            var filteredHistory = _bd.History
                .AsEnumerable() // Переключаемся на выполнение в памяти
                .Where(h => searchTerms.All(term =>
                    h.Title.ToLower().Contains(term) ||
                    h.Description.ToLower().Contains(term)))
                .ToList();

            return PartialView("SearchResults", filteredHistory);
        }


        public ActionResult GetAddHistory(int historyId)
        {
            var addHistory = _bd.AddHistory.Where(a => a.DateId == historyId).ToList();
            foreach (var history in addHistory)
            {
                history.Description = ConvertMarkdownToHtml(history.Description);
            }
            return PartialView("AddHistoryDetails", addHistory);
        }

        public string ConvertMarkdownToHtml(string markdown)
        {
            // Создаем экземпляр Markdown
            var markdownConverter = new Markdown();
            // Преобразуем Markdown в HTML
            var html = markdownConverter.Transform(markdown);
            return html;
        }
    }
}
