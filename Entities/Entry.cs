using Extratinhos.Entities.Base;
using Extratinhos.Entities.Enums;

namespace Extratinhos.Entities;

public class Entry : BaseEntity
{
    public long Value { get; set; }

    public EntryType Type { get; set; }

    public string? Description { get; set; }

    public long ClientId { get; set; }

    public Client? Client { get; set; } = null;
}

