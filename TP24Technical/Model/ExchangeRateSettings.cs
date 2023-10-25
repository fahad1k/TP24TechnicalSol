namespace TP24Technical.Model;
/// <summary>
///  ExchangeRateSettings is a configuration class used to store settings related to exchange rates.
/// </summary>
public class ExchangeRateSettings
{
    // BaseUrl represents the base URL of the exchange rate API.
    public string BaseUrl { get; set; }

    // AccessKey is an access key or API key used to authenticate with the exchange rate API.
    public string AccessKey { get; set; }

    // BaseCurrency is the currency code that serves as the base for exchange rate conversions.
    public string BaseCurrency { get; set; }
}