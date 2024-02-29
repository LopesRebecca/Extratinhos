using Extratinhos.Context;

namespace extratinhos.api.Repositories;

public class UnitOfWork
{
    private ExtratinhoContext _context { get; set; }

    public UnitOfWork(ExtratinhoContext context)
    {
        _context = context;
    }

    public void Commit() =>  _context.SaveChanges();

    public void Rollback() => _context.ChangeTracker.Clear();
}