using Extratinhos.Entities;
using Microsoft.EntityFrameworkCore;

namespace Extratinhos.Context;

public class ExtratinhoContext : DbContext
{
    public DbSet<Client> Clients { get; set; }

    public DbSet<Entry> Entries { get; set; }

    public DbSet<Balance> Balances { get; set; }

    public ExtratinhoContext(DbContextOptions<ExtratinhoContext> options) : base(options) { }
}
