using TP24Technical.Services; 

/// <summary>
/// The `ReceivableService` class implements the `IReceivableService` interface
/// to provide a service for managing receivable entities. It interacts with the
/// repository for performing CRUD (Create, Read, Update, Delete) operations on receivables.
/// </summary>
public class ReceivableService : IReceivableService
{
    private readonly IRepository<Receivable> _repository;

    /// <summary>
    /// Initializes a new instance of the `ReceivableService` class with the specified
    /// repository for managing receivable entities.
    /// </summary>
    /// <param name="_repository">The repository for working with receivables.</param>
    public ReceivableService(IRepository<Receivable> _repository)
    {
        this._repository = _repository;
    }

    /// <inheritdoc />
    public async Task<Receivable> GetReceivableByIdAsync(string id)
    {
        // Implementation details for retrieving a receivable by ID from the repository.
        return await _repository.GetByIdAsync(id);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Receivable>> GetAllReceivablesAsync()
    {
        // Implementation details for retrieving all receivables from the repository.
        return await _repository.GetAllAsync();
    }

    /// <inheritdoc />
    public async Task AddReceivableAsync(Receivable receivable)
    {
        // Implementation details for adding a new receivable to the repository.
        await _repository.AddAsync(receivable);
    }

    /// <inheritdoc />
    public async Task UpdateReceivableAsync(Receivable receivable)
    {
        // Implementation details for updating an existing receivable in the repository.
        await _repository.UpdateAsync(receivable);
    }

    /// <inheritdoc />
    public async Task DeleteReceivableAsync(string id)
    {
        var receivable = await _repository.GetByIdAsync(id);
        if (receivable != null)
        {
            // Implementation details for deleting a receivable by ID from the repository.
            await _repository.DeleteAsync(receivable);
        }
    }
}
