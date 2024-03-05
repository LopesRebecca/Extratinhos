using Extratinhos.Entities.Enums;
using System.Text.Json.Serialization;

namespace Extratinhos.DTOs.Response;

public class EntryResponse
{
     [JsonPropertyName("valor")]
    public long Value { get; set; }

    [JsonPropertyName("tipo")]
    public EntryType Type { get; set; }

    [JsonPropertyName("descricao")]
    public string Description { get; set; }

    [JsonPropertyName("realizada_em")]
    public DateTime RealizedAt { get; set; }
}
