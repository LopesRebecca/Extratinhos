using Extratinhos.Entities.Base;

namespace Extratinhos.Entities;

public class Client : BaseEntity
{
    public long Limit { get; set; }

    public ICollection<Entry> Entrys { get; set; }

    public Balance Balance { get; set; }
}
