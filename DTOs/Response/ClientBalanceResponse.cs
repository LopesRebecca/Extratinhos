using System.Text.Json.Serialization;

namespace Extratinhos.DTOs.Response;

public class ClientBalanceResponse
{
    [JsonPropertyName("limite ")]
    public long Limit { get; set; }

    [JsonPropertyName("saldo")]
    public long Balance { get; set; } 
}

