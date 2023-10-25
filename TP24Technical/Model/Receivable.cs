
namespace TP24Technical.Model;

public class Receivable  : IEntity
{
    [Key]
    [Required(ErrorMessage = "Reference required")]
    [JsonPropertyName("reference")]
    public string Reference { get; set; }

    [JsonPropertyName("currencyCode")]
    public string CurrencyCode { get; set; }

    [JsonPropertyName("issueDate")]
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime IssueDate { get; set; }

    [JsonPropertyName("openingValue")]
    public decimal OpeningValue { get; set; }

    [JsonPropertyName("paidValue")]
    public decimal PaidValue { get; set; }

    [JsonPropertyName("dueDate")]
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime DueDate { get; set; }

    [JsonPropertyName("closedDate")]
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime? ClosedDate { get; set; }

    [JsonPropertyName("cancelled")]
    public bool Cancelled { get; set; }

    [JsonPropertyName("debtorName")]
    public string DebtorName { get; set; }

    [JsonPropertyName("debtorReference")]
    public string DebtorReference { get; set; }

    [JsonPropertyName("debtorAddress1")]
    public string DebtorAddress1 { get; set; }

    [JsonPropertyName("debtorAddress2")]
    public string DebtorAddress2 { get; set; }

    [JsonPropertyName("debtorTown")]
    public string DebtorTown { get; set; }

    [JsonPropertyName("debtorState")]
    public string DebtorState { get; set; }

    [JsonPropertyName("debtorZip")]
    public string DebtorZip { get; set; }

    [JsonPropertyName("debtorCountryCode")]
    public string DebtorCountryCode { get; set; }

    [JsonPropertyName("debtorRegistrationNumber")]
    public string DebtorRegistrationNumber { get; set; }

    [JsonPropertyName("baseCurrencyOpeningValue")]
    public decimal BaseCurrencyOpeningValue { get; set; }

    [JsonPropertyName("baseCurrencyPaidValue")]
    public decimal BaseCurrencyPaidValue { get; set; }

}


public class JsonDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            //if (DateTime.TryParseExact(reader.GetString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            if (DateTime.TryParse(reader.GetString(), CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                return date;
            }
        }

        throw new JsonException("Invalid date format");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }
}
