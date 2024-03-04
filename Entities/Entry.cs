using Extratinhos.Entities.Base;
using Extratinhos.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Extratinhos.Entities;

public class Entry : BaseEntity
{
    public long Value { get; set; }

    public EntryType Type { get; set; }

    public string? Description { get; set; }

    [ForeignKey("ClientId")]
    public long ClientId { get; set; }

    public Client? Client { get; set; } = null;
}

