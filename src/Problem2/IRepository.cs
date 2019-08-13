namespace src.Problem2
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
    }
}