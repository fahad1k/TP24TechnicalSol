
namespace TP24Technical.Services;

public interface IReceivableService
{
     Task<Receivable> GetReceivableByIdAsync(string id);

     Task<IEnumerable<Receivable>> GetAllReceivablesAsync();

     Task AddReceivableAsync(Receivable receivable);

     Task UpdateReceivableAsync(Receivable receivable);


     Task DeleteReceivableAsync(string id);

}
