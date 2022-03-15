using Microsoft.EntityFrameworkCore;

namespace ProjetoInicial.Repository.RepositoryBase
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext contexto)
        {
            this.Context = contexto;
        }
        public void Add(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }

        public IQueryable<T> All()
        {
            return Context.Set<T>();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Delete(T item)
        {
            Context.Set<T>().Remove(item);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Update(T item)
        {
            Context.Entry(Update).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public T GetById(object id)
        {
            return Context.Set<T>().Find(id);
        }
    }
}
