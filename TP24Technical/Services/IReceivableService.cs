namespace TP24Technical.Services;

/// <summary>
/// The `IReceivableService` interface defines the contract for working with receivable entities.
/// It provides methods to interact with and manipulate receivable data.
/// </summary>
public interface IReceivableService
{
    /// <summary>
    /// Retrieves a receivable by its unique reference identifier asynchronously.
    /// </summary>
    /// <param name="id">The reference identifier of the receivable to retrieve.</param>
    /// <returns>An instance of the receivable if found, or null if not found.</returns>
    Task<Receivable> GetReceivableByIdAsync(string id);

    /// <summary>
    /// Retrieves all receivables from the data store asynchronously.
    /// </summary>
    /// <returns>A collection of receivables.</returns>
    Task<IEnumerable<Receivable>> GetAllReceivablesAsync();

    /// <summary>
    /// Adds a new receivable to the data store asynchronously.
    /// </summary>
    /// <param name="receivable">The receivable to be added.</param>
    Task AddReceivableAsync(Receivable receivable);

    /// <summary>
    /// Updates an existing receivable in the data store asynchronously.
    /// </summary>
    /// <param name="receivable">The receivable to be updated.</param>
    Task UpdateReceivableAsync(Receivable receivable);

    /// <summary>
    /// Deletes a receivable from the data store asynchronously based on its reference identifier.
    /// </summary>
    /// <param name="id">The reference identifier of the receivable to delete.</param>
    Task DeleteReceivableAsync(string id);
}
