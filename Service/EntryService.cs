using extratinhos.api.Repositories;

using Extratinhos.Context;
using Extratinhos.DTOs;
using Extratinhos.DTOs.Response;
using Extratinhos.Entities;
using Extratinhos.Entities.Enums;

namespace Extratinhos.Service;

public class EntryService
{
    private readonly EntrysRepository _entrysRepository;

    public EntryService(ExtratinhoContext context)
    {
        _entrysRepository = new EntrysRepository(context);
    }

    public Entry CreateEntry(EntryRequest request, Client client)
    {
        Entry entry = new()
        {
            Value = request.Value,
            Type = request.Type == "c" ? EntryType.CREDIT : EntryType.DEBIT,
            Description = request.Description,
            ClientId = client.Id,
            Client = client,
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

    public IEnumerable<Entry> GenerateEntriesResponseByClientId(long clientId, int index = 0 , int totalItens = 10)
    {
        return _entrysRepository.GetEntriesPaginatedByClientId(clientId, index, totalItens);
    }

    public IEnumerable<EntryResponse> GetEntriesPaginatedByClientId(long clientId, int index = 0 , int totalItens = 10)
    {
        var entries = _entrysRepository.GetEntriesPaginatedByClientId(clientId, index, totalItens);
        
        var response = entries.Select(x => new EntryResponse
        {
            Description = x.Description,
            RealizedAt = x.CreatedAt,
            Type = x.Type,
            Value = x.Value
        });
     
        return response;
    }
}
