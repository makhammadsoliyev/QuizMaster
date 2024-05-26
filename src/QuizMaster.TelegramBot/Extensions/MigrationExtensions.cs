using Microsoft.EntityFrameworkCore;
using QuizMaster.DataAccess.Contexts;

namespace QuizMaster.TelegramBot.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Database.Migrate();
    }
}
