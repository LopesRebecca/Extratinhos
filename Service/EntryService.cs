using extratinhos.api.Repositories;
using Extratinhos.DTOs;
using Extratinhos.Entities;
using Extratinhos.Entities.Enums;

namespace Extratinhos.Service;

public class EntryService
{
    private readonly EntrysRepository _entrysRepository;

    public EntryService(EntrysRepository entrysRepository)
    {
        _entrysRepository = entrysRepository;
    }

    public Entry CreateEntry(EntryRequest request, long Id)
    {
        Entry entry = new()
        {
            Value = request.Value,
            Type = request.Type == "c" ? EntryType.CREDIT : EntryType.DEBIT,
            Description = request.Description,
            ClientId = Id,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        _entrysRepository.Insert(entry).Save();

        return entry;
    }

    public Entry GetEntryByClientId(long Id)
    {
        return _entrysRepository.GetByClientId(Id);
    }


}
