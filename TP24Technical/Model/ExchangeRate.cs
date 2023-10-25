

namespace TP24Technical.Model;


public class ExchangeRate
{
    [JsonPropertyName("result")]
    public string? Result { get; set; }

    [JsonPropertyName("documentation")]
    public string? Documentation { get; set; }
    
    [JsonPropertyName("terms_of_use")]
    public string? TermsofUse { get; set; }

    [JsonPropertyName("time_last_update_unix")]
    public int TimeLastUpdateUNIX { get; set; }

    [JsonPropertyName("time_last_update_utc")]
    public string? TimeLastUpdateUTC { get; set; }

    [JsonPropertyName("time_next_update_unix")]
    public int TimeNextUpdateUNIX { get; set; }

    [JsonPropertyName("time_next_update_utc")]
    public string? TimeNextUpdateUTC { get; set; }

    [JsonPropertyName("base_code")]
    public string? BaseCode { get; set; }

    [JsonPropertyName("conversion_rates")]
    public Dictionary<string, decimal>? ConversionRates { get; set; }

    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; } // Include this property for error messages

}
