using Extratinhos.Entities.Base;

namespace Extratinhos.Entities;

public class Balance : BaseEntity
{
    public long Value { get; set; }

    public long ClientId { get; set; }

    public Client? Client { get; set; } = null;
}
