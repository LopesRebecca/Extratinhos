using Extratinhos.Context;
using Extratinhos.Entities;
using Microsoft.EntityFrameworkCore;

namespace extratinhos.api.Repositories;

public class ClientRepository : IRepository<Client>
{
    private ExtratinhoContext _context;

    public ClientRepository(ExtratinhoContext context)
    {
        _context = context;
    }

    public List<Client> GetAll() => _context.Clients.AsNoTracking().ToList();

    public Client? GetById(long id) => _context.Clients.FirstOrDefault(c => c.Id == id);

    public IRepository<Client> Insert(Client entity)
    {
        _context.Clients.Add(entity);
        return this;
    }

    public IRepository<Client> InsertRange(List<Client> entitys)
    {
        _context.Clients.AddRange(entitys);
        return this;
    }

    public void Save() => _context.SaveChanges();

    public IRepository<Client> Update(Client entity)
    {
        entity.UpdatedAt = DateTime.Now;
        _context.Clients.Update(entity);
        return this;
    }
}
