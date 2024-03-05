using Azure.Core;

using extratinhos.api.Repositories;

using Extratinhos.Context;
using Extratinhos.DTOs;
using Extratinhos.DTOs.Response;
using Extratinhos.Entities;
using Extratinhos.Exceptions;

namespace Extratinhos.Service;

public class BalanceService
{
    private readonly BalanceRepository _balanceRepository;
    private readonly ClientRepository _clientRepository;


    public BalanceService(ExtratinhoContext context)
    {
        _balanceRepository = new BalanceRepository(context);
        _clientRepository = new ClientRepository(context);
    }

    public Balance CreateBalance(EntryRequest request, Client client, long Value)
    {
        var balance = _balanceRepository.GetByClientId(client.Id);

        var createBalance = false;

        if(balance is null)
        {
            createBalance = true;
            balance = new()
            {
                Value = Value,
                ClientId = client.Id,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Client = client,
            };
        }

        if (request.Equals('d'))
        {
            balance.Value -= request.Value;

            if (client.Limit + balance.Value < 0)
                throw new LimitException();
        }
        else
            balance.Value += request.Value;

        
        if(createBalance)
            _balanceRepository.Insert(balance).Save();

        _balanceRepository.Update(balance)
                          .Save();

        return balance;
    }

    public BalanceResponse GererateBalanceResponseByClient(long Id)
    {
        var balance = _balanceRepository.GetByClientId(Id);

        var response = new BalanceResponse
        {
            Total = balance.Value,
            Limit = balance.Client.Limit,
            BalanceDate = DateTime.Now,
        };

        return response;
    }
}
