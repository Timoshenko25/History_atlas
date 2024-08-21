using PromHistory.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Настройка служб
        builder.Services.AddDbContext<HistoryContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Настройка маршрутизации
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=HistoricalEvents}/{action=Index}/{id?}");
        });

        app.Run();
    }
}
