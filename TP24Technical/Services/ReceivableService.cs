

namespace TP24Technical.Services;

public class ReceivableService: IReceivableService
{
    private readonly IRepository<Receivable> _repository;

    public ReceivableService(IRepository<Receivable> repository)
    {
        _repository = repository;
    }

    public async Task<Receivable> GetReceivableByIdAsync(string id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Receivable>> GetAllReceivablesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task AddReceivableAsync(Receivable receivable)
    {
        await _repository.AddAsync(receivable);
    }

    public async Task UpdateReceivableAsync(Receivable receivable)
    {
        await _repository.UpdateAsync(receivable);
    }

    public async Task DeleteReceivableAsync(string id)
    {
        var receivable = await _repository.GetByIdAsync(id);
        if (receivable != null)
        {
            await _repository.DeleteAsync(receivable);
        }
    }
}
