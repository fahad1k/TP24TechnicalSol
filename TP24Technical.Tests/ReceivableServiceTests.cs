namespace TP24Technical.Tests;

[TestFixture]
public class ReceivableServiceTests
{
    private IReceivableService _receivableService;
    private IRepository<Receivable> _repository;

    [SetUp]
    public void Setup()
    {
        // Arrange: Initialize test dependencies
        _repository = Substitute.For<IRepository<Receivable>>();
        _receivableService = new ReceivableService(_repository);
    }

    [Test]
    public async Task GetReceivableByIdAsync_ExistingId_ReturnsReceivable()
    {
        // Arrange: Prepare data for the test
        const string existingId = "Reference-0";
        var expectedReceivable = new Receivable { Reference = existingId };
        _repository.GetByIdAsync(existingId).Returns(Task.FromResult(expectedReceivable));

        // Act: Execute the test
        var result = await _receivableService.GetReceivableByIdAsync(existingId);

        // Assert: Verify the test result
        Assert.AreEqual(existingId, result.Reference);
    }

    [Test]
    public async Task GetReceivableByIdAsync_NonExistingId_ReturnsNull()
    {
        // Arrange: Prepare data for the test
        const string nonExistingId = "NonExistingReference";
        _repository.GetByIdAsync(nonExistingId).Returns(Task.FromResult((Receivable)null));

        // Act: Execute the test
        var result = await _receivableService.GetReceivableByIdAsync(nonExistingId);

        // Assert: Verify the test result
        Assert.IsNull(result);
    }

    [Test]
    public async Task GetAllReceivablesAsync_ReturnsAllReceivables()
    {
        // Arrange: Prepare data for the test
        var expectedReceivables = new List<Receivable>
        {
            new Receivable { Reference = "Reference-1" },
            new Receivable { Reference = "Reference-2" },
            new Receivable { Reference = "Reference-3" }
        };
        _repository.GetAllAsync().Returns(expectedReceivables);

        // Act: Execute the test
        var result = await _receivableService.GetAllReceivablesAsync();

        // Assert: Verify the test result
        CollectionAssert.AreEqual(expectedReceivables, result);
    }

    [Test]
    public async Task AddReceivableAsync_ValidReceivable_CallsRepositoryAddAsync()
    {
        // Arrange: Prepare data for the test
        var receivableToAdd = new Receivable { Reference = "NewReceivable" };

        // Act: Execute the test
        await _receivableService.AddReceivableAsync(receivableToAdd);

        // Assert: Verify that the repository's AddAsync method was called
        await _repository.Received(1).AddAsync(receivableToAdd);
    }

    [Test]
    public async Task UpdateReceivableAsync_ValidReceivable_CallsRepositoryUpdateAsync()
    {
        // Arrange: Prepare data for the test
        var receivableToUpdate = new Receivable { Reference = "ExistingReceivable" };

        // Act: Execute the test
        await _receivableService.UpdateReceivableAsync(receivableToUpdate);

        // Assert: Verify that the repository's UpdateAsync method was called
        await _repository.Received(1).UpdateAsync(receivableToUpdate);
    }

    [Test]
    public async Task DeleteReceivableAsync_ExistingId_CallsRepositoryDeleteAsync()
    {
        // Arrange: Prepare data for the test
        const string existingId = "Reference-4";
        var existingReceivable = new Receivable { Reference = existingId };
        _repository.GetByIdAsync(existingId).Returns(Task.FromResult(existingReceivable));

        // Act: Execute the test
        await _receivableService.DeleteReceivableAsync(existingId);

        // Assert: Verify that the repository's DeleteAsync method was called
        await _repository.Received(1).DeleteAsync(existingReceivable);
    }

    [Test]
    public async Task DeleteReceivableAsync_NonExistingId_DoesNotCallRepositoryDeleteAsync()
    {
        // Arrange: Prepare data for the test
        const string nonExistingId = "NonExistingReference";
        _repository.GetByIdAsync(nonExistingId).Returns(Task.FromResult((Receivable)null));

        // Act: Execute the test
        await _receivableService.DeleteReceivableAsync(nonExistingId);

        // Assert: Verify that the repository's DeleteAsync method was not called
        await _repository.DidNotReceive().DeleteAsync(Arg.Any<Receivable>());
    }
}
