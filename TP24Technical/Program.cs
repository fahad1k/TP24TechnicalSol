

namespace TP24Technical;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped(typeof(IReceivableService ), typeof(ReceivableService));
     
        builder.Services.AddScoped<DataSeeder>();


        // Add services to the container.
        builder.Services.AddDbContext<ReceivableDbContext>(options =>
        options.UseInMemoryDatabase("InMemoryDatabase"));

        builder.Services.AddControllers()
         .AddJsonOptions(options =>
          {
              options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
          });
        // Add HttpClient
        builder.Services.AddHttpClient();

        // Add configuration for ExchangeRateSettings
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        builder.Services.Configure<ExchangeRateSettings>(builder.Configuration.GetSection("ExchangeRateSettings"));
        builder.Services.AddScoped(typeof(IExchangeRatesService), typeof(ExchangeRateapiService));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();


        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ReceivableDbContext>();
            var dataSeeder = services.GetRequiredService<DataSeeder>();
            dataSeeder.SeedReceivables();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

