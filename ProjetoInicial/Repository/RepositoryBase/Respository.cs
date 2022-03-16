using Microsoft.EntityFrameworkCore;
using ProjetoInicial.Data;

namespace ProjetoInicial.Repository.RepositoryBase
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected Context _context = new Context();

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public IQueryable<T> All()
        {
            return _context.Set<T>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Update(T item)
        {
            _context.Entry(Update).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
