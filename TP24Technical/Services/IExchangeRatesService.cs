

namespace TP24Technical.Services;

/// <summary>
/// The `IExchangeRatesService` interface defines a contract for services that retrieve exchange rates.
/// Implementing classes should provide an asynchronous method to fetch exchange rate information.
/// </summary>
public interface IExchangeRatesService
{
    /// <summary>
    /// Retrieves exchange rate information asynchronously.
    /// </summary>
    /// <returns>An asynchronous task that will resolve to an `ExchangeRate` object.</returns>
    Task<ExchangeRate> GetExchangeRatesAsync();
}
