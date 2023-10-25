

namespace TP24Technical.DBContexts;

public class ReceivableDbContext : DbContext
{
    public ReceivableDbContext(DbContextOptions<ReceivableDbContext> options)
        : base(options)
    {
    }

    public DbSet<Receivable> Receivables { get; set; }
}

