namespace TP24Technical.Services;
/// <summary>
/// The `ExchangeRateapiService` class implements the `IExchangeRatesService` interface
/// and is responsible for fetching exchange rate data from an API.
/// </summary>
public class ExchangeRateapiService : IExchangeRatesService
{
    private readonly IHttpClientFactory _httpClientFactory; // Factory for creating HTTP clients.
    private readonly ExchangeRateSettings _exchangeRateSettings; // Configuration settings.
    private const string TO_REPLACE_KEY = "YOUR_ACCESS_KEY"; // Key to replace in the base URL.

    /// <summary>
    /// Initializes a new instance of the `ExchangeRateapiService` class.
    /// </summary>
    /// <param name="httpClientFactory">A factory for creating HTTP clients.</param>
    /// <param name="exchangeRateSettings">Configuration settings for exchange rates.</param>
    public ExchangeRateapiService(IHttpClientFactory httpClientFactory, IOptions<ExchangeRateSettings> exchangeRateSettings)
    {
        _httpClientFactory = httpClientFactory;
        _exchangeRateSettings = exchangeRateSettings.Value;

        // Replace a placeholder in the base URL with the actual access key.
        _exchangeRateSettings.BaseUrl = _exchangeRateSettings.BaseUrl.Replace(TO_REPLACE_KEY, _exchangeRateSettings.AccessKey);
    }

    /// <inheritdoc />
    public async Task<ExchangeRate> GetExchangeRatesAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var apiUrl = $"{_exchangeRateSettings.BaseUrl}/{_exchangeRateSettings.BaseCurrency}";

        try
        {
            // Make an HTTP GET request to the exchange rate API.
            var response = await client.GetStringAsync(apiUrl);

            // Use System.Text.Json for deserialization.
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Deserialize the API response into an `ExchangeRate` object.
            return JsonSerializer.Deserialize<ExchangeRate>(response, options);
        }
        catch (HttpRequestException ex)
        {
            // Handle the HTTP request exception and return a failure response.
            return new ExchangeRate
            {
                Result = ex.StatusCode.ToString(),
                ErrorMessage = ex.Message
            };
        }
    }
}