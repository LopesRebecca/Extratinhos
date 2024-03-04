using Extratinhos.Context;
using Extratinhos.DTOs;
using Extratinhos.Entities;
using Extratinhos.Service;
using Microsoft.AspNetCore.Mvc;

namespace Extratinhos.Controllers;

[Route("[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private ClientService _clientService;
    private EntryService _entryService;
    private BalanceService _balanceService;

    public ClientController(ExtratinhoContext context)
    {
        _clientService = new ClientService(new extratinhos.api.Repositories.ClientRepository(context));
        _entryService = new EntryService(new extratinhos.api.Repositories.EntrysRepository(context));
        _balanceService = new BalanceService(new extratinhos.api.Repositories.BalanceRepository(context));

    }

    [HttpGet]
    public ActionResult<IEnumerable<Client>> GetClientList()
    {
        IEnumerable<Client> users = _clientService.GetClientList();
        if (users is null) { return NotFound(); }
        return users.ToList();
    }

    [HttpGet("{Id:long}")]
    public ActionResult<Client> GetClientById(long Id)
    {
        var user = _clientService.GetClientById(Id);
        if (user is null) { return NotFound(); }
        return user;
    }

    [HttpPost]
    public ActionResult<Client> CreateClient([FromBody] ClientRequest request)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        var client = _clientService.CreateClient(request);

        if (client.Id is 0)
            return BadRequest();
        else
            return Ok(client);
    }

    [HttpPut("{Id:long}")]
    public ActionResult<Client> UpdateClient(long Id, Client client)
    {
        if (Id != client.Id) { return BadRequest(); }

        client = _clientService.UpdateClient(client);

        return Ok(client);
    }

    [HttpPost("{Id:long}/trasacoes")]
    public ActionResult<ReturnClientTransaction> CreateEntry([FromBody] EntryRequest request, long Id)
    {
        if (!ModelState.IsValid || Id is 0) { return BadRequest(ModelState); }

        var client = _clientService.GetClientById(Id);

        if (client is null)
            throw new ArgumentOutOfRangeException("Client not found");

        var entry = _entryService.CreateEntry(request, client.Id);
        var balance = _balanceService.CreateBalance(client.Id, (client.Limit - entry.Value));

        ReturnClientTransaction result = new ReturnClientTransaction()
        {
            Balance = balance.Value,
            Limit = client.Limit
        };

        return Ok(result);
    }

    [HttpPost("{Id:long}/extrato")]
    public ActionResult<ReturnClientTransaction> GetBalance(long Id)
    {
        if (!ModelState.IsValid || Id is 0) { return BadRequest(ModelState); }

        var client = _clientService.GetClientById(Id);

        if (client is null)
            throw new ArgumentOutOfRangeException("Client not found");

        var entry = _entryService.GetEntryByClientId(client.Id);
        var balance = _balanceService.GetBalanceByClientId(client.Id);

        ReturnBalanceClient result = new ReturnBalanceClient()
        {
            entry = entry,
            balance = balance
        };

        return Ok(result);
    }
}
