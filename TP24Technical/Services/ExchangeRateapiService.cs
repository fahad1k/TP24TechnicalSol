

namespace TP24Technical.Services;

public class ExchangeRateapiService : IExchangeRatesService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ExchangeRateSettings _exchangeRateSettings;
    private const string TO_REPLACE_KEY = "YOUR_ACCESS_KEY";

    public ExchangeRateapiService(IHttpClientFactory httpClientFactory, IOptions<ExchangeRateSettings> exchangeRateSettings)
    {
        _httpClientFactory = httpClientFactory;
        _exchangeRateSettings = exchangeRateSettings.Value;
        _exchangeRateSettings.BaseUrl= _exchangeRateSettings.BaseUrl.Replace(TO_REPLACE_KEY, _exchangeRateSettings.AccessKey);
    }

    public async Task<ExchangeRate> GetExchangeRatesAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var apiUrl = $"{_exchangeRateSettings.BaseUrl}/{_exchangeRateSettings.BaseCurrency}";
       
        try
        {

            var response = await client.GetStringAsync(apiUrl);
            // Use System.Text.Json for deserialization
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<ExchangeRate>(response, options);
        }
        catch (HttpRequestException ex)
        {
            // Handle the HTTP request exception and return a failure response
            return new ExchangeRate
            {
                Result = ex.StatusCode.ToString(),
                ErrorMessage = ex.Message
            };
        }
    }
}
