namespace TP24Technical.Model;

public class ExchangeRate
{
    /// <summary>
    /// Gets or sets the result of the exchange rate retrieval operation.
    /// This can be a status code or a success indicator.
    /// </summary>
    [JsonPropertyName("result")]
    public string? Result { get; set; }

    /// <summary>
    /// Gets or sets the documentation related to the exchange rate data.
    /// This property provides additional information or documentation.
    /// </summary>
    [JsonPropertyName("documentation")]
    public string? Documentation { get; set; }

    /// <summary>
    /// Gets or sets the terms of use for the exchange rate data.
    /// This property specifies the terms and conditions for using the data.
    /// </summary>
    [JsonPropertyName("terms_of_use")]
    public string? TermsofUse { get; set; }

    /// <summary>
    /// Gets or sets the UNIX timestamp of the last data update.
    /// This represents the time when the data was last updated in UNIX format.
    /// </summary>
    [JsonPropertyName("time_last_update_unix")]
    public int TimeLastUpdateUNIX { get; set; }

    /// <summary>
    /// Gets or sets the UTC time of the last data update.
    /// This represents the time when the data was last updated in UTC format.
    /// </summary>
    [JsonPropertyName("time_last_update_utc")]
    public string? TimeLastUpdateUTC { get; set; }

    /// <summary>
    /// Gets or sets the UNIX timestamp of the next data update.
    /// This represents the time when the data will be updated next in UNIX format.
    /// </summary>
    [JsonPropertyName("time_next_update_unix")]
    public int TimeNextUpdateUNIX { get; set; }

    /// <summary>
    /// Gets or sets the UTC time of the next data update.
    /// This represents the time when the data will be updated next in UTC format.
    /// </summary>
    [JsonPropertyName("time_next_update_utc")]
    public string? TimeNextUpdateUTC { get; set; }

    /// <summary>
    /// Gets or sets the base currency code for the exchange rates.
    /// This is the currency against which other exchange rates are quoted.
    /// </summary>
    [JsonPropertyName("base_code")]
    public string? BaseCode { get; set; }

    /// <summary>
    /// Gets or sets a dictionary representing conversion rates for different currencies.
    /// The keys are currency codes, and the values are the corresponding exchange rates.
    /// </summary>
    [JsonPropertyName("conversion_rates")]
    public Dictionary<string, decimal>? ConversionRates { get; set; }

    /// <summary>
    /// Gets or sets an error message in case of a failed exchange rate retrieval.
    /// This property provides details about the error when the operation is unsuccessful.
    /// </summary>
    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }
}
