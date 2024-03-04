using extratinhos.api.Repositories;
using Extratinhos.Entities;

namespace Extratinhos.Service;

public class BalanceService
{
    private readonly BalanceRepository _balanceRepository;

    public BalanceService(BalanceRepository balanceRepository)
    {
        _balanceRepository = balanceRepository;
    }

    public Balance CreateBalance(long Id, long Value)
    {
        Balance balance = new()
        {
            Value = Value,
            ClientId = Id 
        };

        _balanceRepository.Insert(balance).Save();

        return balance;
    }
}
