using Microsoft.EntityFrameworkCore;

namespace TestApi.Database
{
    public static class AppDbContextStartup
    {
        public static void Run(IServiceProvider services)
        {
            var dbContext = services.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();

            SeedDatabase(dbContext);
        }

        private static void SeedDatabase(AppDbContext dbContext)
        {
            if (dbContext.Customers.Any())
                return;

            dbContext.Orders.Add(new Database.Entities.OrderEty
            {
                CreateAt = DateTime.Parse("2022-10-01T15:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                UpdatedAt = DateTime.Parse("2022-10-01T15:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                ClosedAt = DateTime.Parse("2022-10-01T15:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                ReceivedAt = DateTime.Parse("2022-10-01T15:40:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                Amount = 1500,
                Customer = new Database.Entities.CustomerEty
                {
                    Name = "Rin Tosaka"
                }
            });

            dbContext.SaveChanges();
        }
    }
}
