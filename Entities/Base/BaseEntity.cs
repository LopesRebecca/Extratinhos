using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Extratinhos.Entities.Base;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
