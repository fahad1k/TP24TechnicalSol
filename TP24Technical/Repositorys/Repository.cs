
namespace TP24Technical.Repositorys;
/// <summary>
// Repository<T> is a generic class that implements the IRepository<T> interface. It provides concrete data access methods
// for working with entities of type T, where T is required to be a class that also implements the IEntity interface.
// The IEntity interface ensures that entities have a 'Reference' property that uniquely identifies them.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private readonly ReceivableDbContext _context;
    /// <summary>
    // Constructor that injects the database context for data access.
    /// </summary>
    /// <param name="context"></param>
    public Repository(ReceivableDbContext context)
    {
        _context = context;
    }

    /// <summary>
    // GetByIdAsync retrieves an entity by its unique reference asynchronously.
    /// </summary>
    /// <param name="reference"></param>
    /// <returns></returns>
    //public async Task<T> GetByIdAsync(string id) => await _context.Set<T>().FindAsync(id);
    public async Task<T> GetByIdAsync(string reference)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(x => x.Reference == reference);
    }
    /// <summary>
    // GetAllAsync retrieves all entities of type T from the data store asynchronously.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    /// <summary>
    // AddAsync adds a new entity to the data store asynchronously.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    /// <summary>
    // UpdateAsync updates an existing entity in the data store asynchronously.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
    /// <summary>
    // DeleteAsync removes an existing entity from the data store asynchronously.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}

