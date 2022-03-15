namespace ProjetoInicial.Servicos
{
    public interface IAppServiceBase<T> where T : class
    {
        void Novo(T item);
        IQueryable Pesquisar();
        void Remover(T item);
        void Alterar(T item);

    }
}
