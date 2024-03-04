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
            ClientId = Id,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        _balanceRepository.Insert(balance).Save();

        return balance;
    }

    public Balance GetBalanceByClientId(long Id)
    {
        return _balanceRepository.GetByClientId(Id);
    }
}
