using System.Text.Json.Serialization;

namespace Extratinhos.DTOs.Response;

public class BalanceResponse
{
    [JsonPropertyName("total")]
    public long Total { get; set; }

    [JsonPropertyName("data_extrato")]
    public DateTime BalanceDate { get; set; }

    [JsonPropertyName("limite")]
    public long Limit { get; set; }
}
