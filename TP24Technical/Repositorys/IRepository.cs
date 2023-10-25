namespace TP24Technical.Repositorys;
/// <summary>
///  IRepository is a generic interface used for defining common data access operations for entities of type T.
// It's designed to provide basic CRUD (Create, Read, Update, Delete) operations for entities in a data store.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
