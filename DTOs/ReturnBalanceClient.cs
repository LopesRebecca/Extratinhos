using Extratinhos.Entities;
using System.Text.Json.Serialization;

namespace Extratinhos.DTOs;

public class ReturnBalanceClient
{
    [JsonPropertyName("saldo")]
    public Balance balance { get; set; }

    [JsonPropertyName("ultimas_transacoes")]
    public Entry entry { get; set; }
}
