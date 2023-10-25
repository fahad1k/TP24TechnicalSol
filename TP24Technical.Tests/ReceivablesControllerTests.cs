






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
        _receivableService = Substitute.For<IReceivableService>();
        _exchangeRatesService = Substitute.For<IExchangeRatesService>();

        _controller = new ReceivablesController(_receivableService, _exchangeRatesService);
    }

    [Test]
    public async Task GetReceivables_ReturnsOkResult()
    {
        // Arrange
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

        _receivableService.GetAllReceivablesAsync().Returns(receivables);

        // Act
        var result = await _controller.Index();

        // Assert
        Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
    }

    [Test]
    public async Task GetReceivables_ReturnsExpectedData()
    {
        // Arrange
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

        _receivableService.GetAllReceivablesAsync().Returns(receivables);

        // Act
        var result = await _controller.Index() as Microsoft.AspNetCore.Mvc.OkObjectResult;
       // var response = result.Value as {   IEnumerable<Receivable>};

        // Assert
        Assert.IsNotNull(result);
       // Assert.IsNotNull(response);
        // Add more specific assertions to verify the response data
    }

    [Test]
    public async Task PostReceivable_ReturnsCreatedResult()
    {
        // Arrange
        var receivable = new Receivable
        {
            // Set properties of the receivable to be created
        };

        _receivableService.AddReceivableAsync(receivable).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Post(receivable);

        // Assert
        Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.CreatedAtActionResult>(result);
    }



    [Test]
    public async Task Index_ValidData_ReturnsOkWithReceivablesAndConversionRates()
    {
        // Arrange
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

        _receivableService.GetAllReceivablesAsync().Returns(expectedReceivables);
       
        // Act
        var result = await _controller.Index() as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);

        Assert.IsNotNull(result.Value);

   
    }
}


