using extratinhos.api.Repositories;
using Extratinhos.Entities;

namespace Extratinhos.Service
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client CreateClient(Client client)
        {
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
