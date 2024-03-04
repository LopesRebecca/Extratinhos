using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Extratinhos.DTOs;

public class ClientRequest
{
    [JsonPropertyName("limite")]
    public long Limit { get; set; }
}
