using Microsoft.EntityFrameworkCore;
using Vilmar.Realtime.Chat.Areas.Context;

namespace Vilmar.Realtime.Chat
{
    public static class MigrationsExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
