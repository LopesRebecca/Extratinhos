using System.Text.Json.Serialization;

namespace Extratinhos.DTOs;

public class RerturnClientTransaction
{
    [JsonPropertyName("limite")]
    public long Limit { get; set; }

    [JsonPropertyName("saldo")]
    public long Balance { get; set; }
}
