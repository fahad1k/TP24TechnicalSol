
namespace TP24Technical.Repositorys;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private readonly ReceivableDbContext _context;

    public Repository(ReceivableDbContext context)
    {
        _context = context;
    }

    //public async Task<T> GetByIdAsync(string id) => await _context.Set<T>().FindAsync(id);
    public async Task<T> GetByIdAsync(string reference)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(x => x.Reference == reference);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}

