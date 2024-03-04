using extratinhos.api.Repositories;
using Extratinhos.DTOs;
using Extratinhos.Entities;

namespace Extratinhos.Service
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;
        private readonly EntrysRepository _entrysRepository;
        private readonly BalanceRepository _balanceRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client CreateClient(ClientRequest request)
        {
            Client client = new Client()
            {
                Limit = request.Limit,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _clientRepository.Insert(client).Save();

            return client;
        }

        public Client UpdateClient(Client client)
        {
            _clientRepository.Update(client).Save();

            return client;
        }

        public Client GetClientById(long id)
        {
            return _clientRepository.GetById(id);
        }

        public IEnumerable<Client> GetClientList()
        {
            return _clientRepository.GetAll();
        }
    }
}
