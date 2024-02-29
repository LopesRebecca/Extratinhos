using extratinhos.api.Repositories;
using Extratinhos.DTOs;
using Extratinhos.Entities;
using Extratinhos.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Extratinhos.Service
{
    public class EntryService
    {

        private readonly EntrysRepository _entrysRepository;
        private readonly ClientService _clientService;

        public EntryService(EntrysRepository entrysRepository, ClientService clientService)
        {
            _entrysRepository = entrysRepository;
            _clientService = clientService;
        }

        public Entry CreateEntry(EntryRequest request)
        {
            //client = _clientService.GetClientById(client.Id);
            //if (client == null)
            //    throw new ArgumentOutOfRangeException("Client not found");

            Entry entry = new()
            {
                Value = request.Value,
                Type = request.Type == "c" ? EntryType.CREDIT : EntryType.DEBIT,
                Description = request.Description
            };

            _entrysRepository.Insert(entry).Save();

            return entry;
        }
    }
}
