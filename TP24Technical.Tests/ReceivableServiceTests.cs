

namespace TP24Technical.Tests;

[TestFixture]
public class ReceivableServiceTests
{
    private IReceivableService _receivableService;
    private IRepository<Receivable> _repository;

    [SetUp]
    public void Setup()
    {
        _repository = Substitute.For<IRepository<Receivable>>();
        _receivableService = new ReceivableService(_repository);
    }

    [Test]
    public async Task GetReceivableByIdAsync_ExistingId_ReturnsReceivable()
    {
        // Arrange
        const string existingId = "Reference-0";
        var expectedReceivable = new Receivable { Reference = existingId };
        _repository.GetByIdAsync(existingId).Returns(Task.FromResult(expectedReceivable));

        // Act
        var result = await _receivableService.GetReceivableByIdAsync(existingId);

        // Assert
        Assert.AreEqual(existingId, result.Reference);
    }

    [Test]
    public async Task GetReceivableByIdAsync_NonExistingId_ReturnsNull()
    {
        // Arrange
        const string nonExistingId = "NonExistingReference";
        _repository.GetByIdAsync(nonExistingId).Returns(Task.FromResult((Receivable)null));

        // Act
        var result = await _receivableService.GetReceivableByIdAsync(nonExistingId);

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public async Task GetAllReceivablesAsync_ReturnsAllReceivables()
    {
        // Arrange
        var expectedReceivables = new List<Receivable>
        {
            new Receivable { Reference = "Reference-1" },
            new Receivable { Reference = "Reference-2" },
            new Receivable { Reference = "Reference-3" }
        };

       

        _repository.GetAllAsync().Returns(expectedReceivables);

        // Act
        var result = await _receivableService.GetAllReceivablesAsync();

        // Assert
        CollectionAssert.AreEqual(expectedReceivables, result);
    }

    [Test]
    public async Task AddReceivableAsync_ValidReceivable_CallsRepositoryAddAsync()
    {
        // Arrange
        var receivableToAdd = new Receivable { Reference = "NewReceivable" };

        // Act
        await _receivableService.AddReceivableAsync(receivableToAdd);

        // Assert
        await _repository.Received(1).AddAsync(receivableToAdd);
    }

    [Test]
    public async Task UpdateReceivableAsync_ValidReceivable_CallsRepositoryUpdateAsync()
    {
        // Arrange
        var receivableToUpdate = new Receivable { Reference = "ExistingReceivable" };

        // Act
        await _receivableService.UpdateReceivableAsync(receivableToUpdate);

        // Assert
        await _repository.Received(1).UpdateAsync(receivableToUpdate);
    }

    [Test]
    public async Task DeleteReceivableAsync_ExistingId_CallsRepositoryDeleteAsync()
    {
        // Arrange
        const string existingId = "Reference-4";
        var existingReceivable = new Receivable { Reference = existingId };
        _repository.GetByIdAsync(existingId).Returns(Task.FromResult(existingReceivable));

        // Act
        await _receivableService.DeleteReceivableAsync(existingId);

        // Assert
        await _repository.Received(1).DeleteAsync(existingReceivable);
    }

    [Test]
    public async Task DeleteReceivableAsync_NonExistingId_DoesNotCallRepositoryDeleteAsync()
    {
        // Arrange
        const string nonExistingId = "NonExistingReference";
        _repository.GetByIdAsync(nonExistingId).Returns(Task.FromResult((Receivable)null));

        // Act
        await _receivableService.DeleteReceivableAsync(nonExistingId);

        // Assert
        await _repository.DidNotReceive().DeleteAsync(Arg.Any<Receivable>());
    }
}
