namespace extratinhos.api.Repositories;

public interface IRepository<T>
{
    public void Save();

    public IRepository<T> Insert(T entity);

    public IRepository<T> Update(T entity);

    public IRepository<T> InsertRange(List<T> entitys);

    public List<T> GetAll();

    public T? GetById(long id);
}
