namespace ProjetoInicial.Respository
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T GetById(object id);
        IQueryable<T> All();
        void Commit();
        void Dispose();

    }
}
