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

    public ClientController(ClientService service) { _clientService = service; }

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

        Client client = new Client() { Limit = request.Limit };

        client = _clientService.CreateClient(client);
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
}
