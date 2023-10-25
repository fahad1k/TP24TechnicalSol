

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP24Technical.Controllers;
[ApiController]
[Route("[controller]")]
public class ReceivablesController : ControllerBase
{
    Dictionary<string, decimal> conversionRates = new Dictionary<string, decimal>();
    private readonly IReceivableService _receivableService;
    private readonly IExchangeRatesService _exchangeRatesService;
    public ReceivablesController(IReceivableService receivableService, IExchangeRatesService exchangeRatesService)
    {
        _receivableService = receivableService;
        _exchangeRatesService = exchangeRatesService;

        var exchResut =  _exchangeRatesService.GetExchangeRatesAsync().Result;

        if (exchResut != null && exchResut.Result == "success" && exchResut.ConversionRates?.Count > 0)
        {

            conversionRates = exchResut.ConversionRates;

        }
    }

    [HttpGet]
    [Route("Index")]

    public  async Task<IActionResult> Index()
    {
      var allReceiables = await _receivableService.GetAllReceivablesAsync();

        if (conversionRates.Count > 0)
        {

            foreach (var receivable in allReceiables)
            {
                if (conversionRates.TryGetValue(receivable.CurrencyCode, out var rate))
                {
                    receivable.BaseCurrencyOpeningValue = receivable.OpeningValue / rate;
                    receivable.BaseCurrencyPaidValue = receivable.PaidValue / rate;
                }

            }

        }

        return  Ok(new { AllReceiables= allReceiables.ToList() });

    }

    //[HttpPost]
    [HttpPost]
  
    [Route("Post")]

    public async Task<IActionResult> Post([FromBody] Receivable receivable)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);

        }

        await _receivableService.AddReceivableAsync(receivable);
   

        return CreatedAtAction("GetReceivable", new { id = receivable.Reference }, receivable);

    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetReceivable(string id)
    {
        var receivable = await _receivableService.GetReceivableByIdAsync(id);

        if (receivable == null)
        {
            return NotFound(); // Return a 404 Not Found response if the resource is not found
        }

        return Ok(receivable); // Return a 200 OK response with the retrieved resource
    }


    [HttpGet]
    [Route("Summery")]

    public async Task<IActionResult> Summery()
    {
        
        var allReceiables= await _receivableService.GetAllReceivablesAsync();

        if (conversionRates.Count > 0)
        {

            foreach (var receivable in allReceiables)
            {
                if (conversionRates.TryGetValue(receivable.CurrencyCode, out var rate))
                {
                    receivable.BaseCurrencyOpeningValue = receivable.OpeningValue / rate;
                    receivable.BaseCurrencyPaidValue = receivable.PaidValue / rate;
                }

            }

        }

        var received = allReceiables
            .Where(r => !r.Cancelled && r.ClosedDate is not null)
            .GroupBy(r => r.CurrencyCode)
            .Select(group => new
            {
                CurrencyCode = group.Key,
                TotalAmountReceived = Decimal.Round(group.Sum(r => r.PaidValue), 2),
                TotalAmountToBeReceived = Decimal.Round(group.Sum(r => r.OpeningValue - r.PaidValue), 2),
                TotalAmountToBeReceivedInBaseCurrency =   Decimal.Round(group.Sum(r => r.BaseCurrencyOpeningValue - r.BaseCurrencyPaidValue), 2),
            })
            .ToList();

        var receiveable = allReceiables
            .Where(r => !r.Cancelled && r.ClosedDate is null)
            .GroupBy(r => r.CurrencyCode)
            .Select(group => new
            {
                CurrencyCode = group.Key,
                TotalAmountReceived = Decimal.Round(group.Sum(r => r.PaidValue),2),
                TotalAmountToBeReceived = Decimal.Round( group.Sum(r => r.OpeningValue - r.PaidValue), 2),
                TotalAmountToBeReceivedInBaseCurrency = Decimal.Round(group.Sum(r => r.BaseCurrencyOpeningValue - r.BaseCurrencyPaidValue), 2),
            })
            .ToList();

     var canceled = allReceiables
    .Where(r => r.Cancelled )
    .GroupBy(r => r.CurrencyCode)
    .Select(group => new
    {
        CurrencyCode = group.Key,
        TotalAmountReceived = Decimal.Round(group.Sum(r => r.PaidValue), 2),
        TotalAmountToBeReceived = Decimal.Round(group.Sum(r => r.OpeningValue - r.PaidValue), 2),
        TotalAmountToBeReceivedInBaseCurrency = Decimal.Round(group.Sum(r => r.BaseCurrencyOpeningValue - r.BaseCurrencyPaidValue), 2),
    })
    .ToList();


            var totalLended = allReceiables
            .Where(r => !r.Cancelled).Sum(r => r.BaseCurrencyOpeningValue);

            var totalReceived = allReceiables
            .Where(r => !r.Cancelled ).Sum(r => r.BaseCurrencyPaidValue);


        return Ok( new { Received = received , Receiveable = receiveable, Canceled= canceled ,TotalLended= totalLended, TotalReceived= totalReceived  , AmountToBeReceived  = totalLended - totalReceived } );

       
    }
}


