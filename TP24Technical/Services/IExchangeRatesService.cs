

namespace TP24Technical.Services;

public interface IExchangeRatesService
{
    Task<ExchangeRate> GetExchangeRatesAsync();
}

