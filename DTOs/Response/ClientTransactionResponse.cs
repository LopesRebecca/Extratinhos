using System.Text.Json.Serialization;

namespace Extratinhos.DTOs.Response;

public class ClientTransactionResponse
{
    [JsonPropertyName("saldo")]
    public BalanceResponse Balance { get; set; }

    [JsonPropertyName("ultimas_transacoes")]
    public List<EntryResponse> Entries { get; set; }
}
