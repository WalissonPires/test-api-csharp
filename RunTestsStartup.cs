using TestApi.Database;

namespace TestApi
{
    public static class RunTestsStartup
    {
        public static void Run(IServiceProvider services)
        {
            var dbContext = services.GetRequiredService<AppDbContext>();

            var result = dbContext.Orders.Where(x => (x.ReceivedAt - x.UpdatedAt).Value.TotalDays > 0).ToList();

            Console.WriteLine(result.Count);
        }
    }
}
