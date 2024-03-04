using System.Text.Json.Serialization;

namespace Extratinhos.DTOs;

public class ReturnClientTransaction
{
    [JsonPropertyName("limite")]
    public long Limit { get; set; }

    [JsonPropertyName("saldo")]
    public long Balance { get; set; }
}
