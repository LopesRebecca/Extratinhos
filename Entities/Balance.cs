using Extratinhos.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Extratinhos.Entities;

public class Balance : BaseEntity
{
    public long Value { get; set; }

    [ForeignKey("ClientId")]
    public long ClientId { get; set; }

    public Client? Client { get; set; } = null;
}
