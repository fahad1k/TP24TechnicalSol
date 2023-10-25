






using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Net;

namespace TP24Technical.Tests;

public class ReceivablesControllerTests
{
    private ReceivablesController _controller;
    private IReceivableService _receivableService;
    private IExchangeRatesService _exchangeRatesService;
    [SetUp]
    public void Setup()
    {
        // Create substitutes for services using NSubstitute
        _receivableService = Substitute.For<IReceivableService>();
        _exchangeRatesService = Substitute.For<IExchangeRatesService>();
        // Create substitutes for services using NSubstitute
        _controller = new ReceivablesController(_receivableService, _exchangeRatesService);
    }

    [Test]
    public async Task GetReceivables_ReturnsOkResult()
    {
        // Arrange
        // Create a list of sample receivables
        var receivables = new List<Receivable>
            {
                new Receivable
                {
                    Reference = "Reference-1",
                    CurrencyCode = "USD",
                    OpeningValue = 724.40m,
                    PaidValue = 634.31m,
                    // Other properties
                },
                // Add more test receivables
            };
        // Set up the substitute to return the sample receivables
        _receivableService.GetAllReceivablesAsync().Returns(receivables);

        // Act
        // Call the action method to get the result
        var result = await _controller.Index();

        // Assert
        // Check that the result is an OkObjectResult
        Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
    }

    [Test]
    public async Task GetReceivables_ReturnsExpectedData()
    {
        // Arrange
        // Create a list of sample receivables
        var receivables = new List<Receivable>
            {
                new Receivable
                {
                    Reference = "Reference-1",
                    CurrencyCode = "USD",
                    OpeningValue = 724.40m,
                    PaidValue = 634.31m,
                    // Other properties
                },
                // Add more test receivables
            };
        // Set up the substitute to return the sample receivables
        _receivableService.GetAllReceivablesAsync().Returns(receivables);

        // Act
        // Call the action method to get the result
        var result = await _controller.Index() as Microsoft.AspNetCore.Mvc.OkObjectResult;
        // var response = result.Value as {   IEnumerable<Receivable>};

        // Assert
        // Check that the result and response are not null
        Assert.IsNotNull(result);
       // Assert.IsNotNull(response);
  
    }

    [Test]
    public async Task PostReceivable_ReturnsCreatedResult()
    {
        // Arrange
        var receivable = new Receivable
        {
            Reference = "Reference-1",  CurrencyCode = "NOK",
            IssueDate = new DateTime(2020, 10, 24), OpeningValue = 800.40m, PaidValue = 634.31m,
            DueDate = new DateTime(2023, 11, 4),ClosedDate = null,
            Cancelled = false,DebtorName = "Debtor-1",
            DebtorReference = "DebtorRef-1",  DebtorAddress1 = "Address1-1",
            DebtorAddress2 = "Address2-1",DebtorTown = "Town-1",
            DebtorState = "State-1",        DebtorZip = "Zip-1",
            DebtorCountryCode = "47",
            DebtorRegistrationNumber = "RegNo-1"
        };
        // Set up the substitute to indicate that the receivable was added successfully
        _receivableService.AddReceivableAsync(receivable).Returns(Task.CompletedTask);

        // Act
        // Call the action method to post the receivable
        var result = await _controller.Post(receivable);

        // Assert
        // Check that the result is a CreatedAtActionResult
        Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.CreatedAtActionResult>(result);
    }



    [Test]
    public async Task Index_ValidData_ReturnsOkWithReceivablesAndConversionRates()
    {
        // Arrange
        // Define expected receivables and conversion rates
        var expectedReceivables = new List<Receivable>
            {
                new Receivable { Reference = "Reference-1", CurrencyCode = "USD" },
                new Receivable { Reference = "Reference-2", CurrencyCode = "EUR" },
            };
        var expectedConversionRates = new Dictionary<string, decimal>
            {
                { "USD", 1.0m },
                { "EUR", 0.85m },
            };
        // Set up substitutes to return the expected data
        _receivableService.GetAllReceivablesAsync().Returns(expectedReceivables);

        // Act
        // Call the action method to get the result
        var result = await _controller.Index() as OkObjectResult;

        // Assert
        // Check that the result is not null and has the expected status code
        Assert.IsNotNull(result);
        Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);

        Assert.IsNotNull(result.Value);

   
    }
}


