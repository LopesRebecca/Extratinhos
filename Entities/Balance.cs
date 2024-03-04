using Extratinhos.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Extratinhos.Entities;

public class Balance : BaseEntity
{
    [JsonPropertyName("total")]
    public long Value { get; set; }

    [ForeignKey("ClientId")]
    [JsonIgnore]
    public long ClientId { get; set; }

    [JsonIgnore]
    public Client? Client { get; set; } = null;
}
