using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Extratinhos.DTOs;

public class ClientRequest
{
    [JsonPropertyName("valor Limite")]
    public long Limit { get; set; }
}
