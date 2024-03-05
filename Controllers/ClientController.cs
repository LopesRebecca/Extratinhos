using Extratinhos.Context;
using Extratinhos.DTOs;
using Extratinhos.DTOs.Response;
using Extratinhos.Entities;
using Extratinhos.Exceptions;
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
        _entryService = new EntryService(context);
        _balanceService = new BalanceService(context);

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
    public ActionResult<ClientTransactionResponse> CreateEntry([FromBody] EntryRequest request, long Id)
    {
        try
        {
            if (!ModelState.IsValid || Id is 0) { return BadRequest(ModelState); }

            var client = _clientService.GetClientById(Id);

            if (client is null)
                return StatusCode(404, new { msg = "Client not found" });

            var _entryType = request.Type.First();
            if (_entryType != 'c' && _entryType != 'd')
                return StatusCode(422, new { msg = "a" });


            if (request.Description.Length > 10)
                return StatusCode(422, new { msg = "b" });

            var entry = _entryService.CreateEntry(request, client);
            var balance = _balanceService.CreateBalance(request, client, (client.Limit - entry.Value));

            var result = new ClientBalanceResponse()
            {
                Balance = balance.Value,
                Limit = client.Limit
            };

            return Ok(result);
        }
        catch(LimitException ex)
        {
            return StatusCode(422, new { msg = "b" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{Id:long}/extrato")]
    public ActionResult<ClientTransactionResponse> GetBalance(long Id)
    {
        if (!ModelState.IsValid || Id is 0) { return BadRequest(ModelState); }

        var client = _clientService.GetClientById(Id);

        if (client is null)
            return StatusCode(404, new { msg = "Client not found" });

        var entry = _entryService.GetEntriesPaginatedByClientId(client.Id);
        var balance = _balanceService.GererateBalanceResponseByClient(client.Id);

        var result = new ClientTransactionResponse()
        {
            Entries = entry.ToList(),
            Balance = balance
        };

        return Ok(result);
    }
}
