using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Extratinhos.DTOs;

public class EntryRequest
{
    [JsonPropertyName("valor")]
    public long Value { get; set; }

    [JsonPropertyName("tipo")]
    [StringLength(1, MinimumLength = 1, ErrorMessage = "The Gender must be 1 characters.")]
    [RegularExpression("c|d", ErrorMessage = "The Gender must be either 'M' or 'F' only.")]
    public string? Type { get; set; }

    [JsonPropertyName("descricao")]
    public string? Description { get; set; }
}
