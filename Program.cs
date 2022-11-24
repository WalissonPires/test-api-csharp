
using Microsoft.EntityFrameworkCore;
using TestApi.Database;
using TestApi.Database.Repositories;

namespace TestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = BuildApp(args);

            ConfigurePipeline(app);
            RunStartupCode(app);

            app.Run();
        }

        private static WebApplication BuildApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            RegisterAppServices(builder);

            return builder.Build();
        }

        private static void RegisterAppServices(WebApplicationBuilder builder)
        {
            var config = builder.Configuration;

            var connectionString = config.GetConnectionString("Default");
            builder.Services.AddDbContext<AppDbContext>(x => x.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

            builder.Services.AddScoped<OrderRepository>();
        }

        private static void ConfigurePipeline(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
        }

        private static void RunStartupCode(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            AppDbContextStartup.Run(scope.ServiceProvider);
            RunTestsStartup.Run(scope.ServiceProvider);
        }
    }
}
    