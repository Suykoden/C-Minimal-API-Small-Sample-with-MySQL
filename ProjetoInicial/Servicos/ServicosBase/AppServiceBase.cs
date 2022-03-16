using ProjetoInicial.Factories;
using ProjetoInicial.Models.ClassesBase;
using ProjetoInicial.Repository;

namespace ProjetoInicial.Servicos.ServicosBase
{

    public abstract class AppServiceBase<T> : IAppServiceBase<T> where T : class, IPossuiId
    {
        private readonly IRepository<T> _repository;
        private readonly IFactoryBase<T> _factory;

        public AppServiceBase(IRepository<T> repository, IFactoryBase<T> factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public void Novo(T item)
          => _repository.Add(_factory.Criar(item));

        public void Alterar(T item)
          => _repository.Update(_repository.GetById(item.Id));

        public IQueryable Pesquisar()
          => _repository.All();

        public void Remover(T item)
         => _repository.Delete(_repository.GetById(item.Id));

        public Task<T> NovoAsync(T item)
        {
            _repository.Add(_factory.Criar(item));
            return  Task.Run(()=> item);
        }
    }
}