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

        // Get exchange rates from a service and store them in conversionRates.

        var exchResut =  _exchangeRatesService.GetExchangeRatesAsync().Result;

        if (exchResut != null && exchResut.Result == "success" && exchResut.ConversionRates?.Count > 0)
        {

            conversionRates = exchResut.ConversionRates;

        }
    }

    /// <summary>
    /// Index endpoint to get All the receivables
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Index")]
    public  async Task<IActionResult> Index()
    {
        // Handle HTTP GET request for receivables.
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
    /// <summary>
    /// insert the new receivable 
    /// </summary>
    /// <param name="receivable"></param>
    /// <returns></returns>
   
    [HttpPost]
    [Route("Post")]
    public async Task<IActionResult> Post([FromBody] Receivable receivable)
    {
        // Handle HTTP POST request to create a new receivable.
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);

        }

        await _receivableService.AddReceivableAsync(receivable);
   

        return CreatedAtAction("GetReceivable", new { id = receivable.Reference }, receivable);

    }

    /// <summary>
    /// Get specific GetReceivable by its refference /id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Gives the summery of the data 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Summery")]
    public async Task<IActionResult> Summery()
    {
        
        var allReceiables= await _receivableService.GetAllReceivablesAsync();

        if (conversionRates.Count > 0)
        {
            // calculates the value of amounts in the base currency 
            foreach (var receivable in allReceiables)
            {
                if (conversionRates.TryGetValue(receivable.CurrencyCode, out var rate))
                {
                    receivable.BaseCurrencyOpeningValue = receivable.OpeningValue / rate;
                    receivable.BaseCurrencyPaidValue = receivable.PaidValue / rate;
                }

            }

        }
            // the open records calculations
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
            // the open records calculations
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

        // summery sent to the user
        return Ok( new { Received = received , Receiveable = receiveable, Canceled= canceled ,TotalLended= totalLended, TotalReceived= totalReceived  , AmountToBeReceived  = totalLended - totalReceived } );

       
    }

    [HttpPost]
    [Route("GraphQL")]
    public async Task<IActionResult> GraphQL([FromBody] string query)
    {

        try
        {
            // Here, you can use a GraphQL library or parser to execute the query against your data.
            // You will need to adapt this part based on your GraphQL library or implementation.
            // This is just a placeholder example.

            var allReceivables = await _receivableService.GetAllReceivablesAsync();

            // Perform filtering, sorting, and shaping of data based on the GraphQL query.

            // Return the result as per your GraphQL implementation.
            // You can use a library like GraphQL.NET, HotChocolate, or another of your choice.

            // Example:
            // var result = YourGraphQLExecutor.Execute(query.Query, allReceivables);

            // Return the result as needed.
             return Ok(allReceivables);
        }
        catch (Exception ex)
        {
            // Handle any errors related to GraphQL query processing.
            return BadRequest(new { message = "GraphQL query execution failed", error = ex.Message });
        }
    }
}


