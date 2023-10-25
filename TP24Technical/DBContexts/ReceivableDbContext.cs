

namespace TP24Technical.DBContexts;
/// <summary>
///  ReceivableDbContext is a class that represents the database context for Receivable entities.
/// </summary>
public class ReceivableDbContext : DbContext
{
    // Constructor for ReceivableDbContext that takes DbContextOptions.
    public ReceivableDbContext(DbContextOptions<ReceivableDbContext> options)
        : base(options)
    {
    }
    // DbSet property representing the collection of Receivable entities in the database.
    public DbSet<Receivable> Receivables { get; set; }

    // The DbSet property allows you to interact with the Receivables table in the database.

}

