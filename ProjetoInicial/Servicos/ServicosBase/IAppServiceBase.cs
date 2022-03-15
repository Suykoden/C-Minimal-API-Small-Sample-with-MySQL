namespace ProjetoInicial.Servicos
{
    public interface IAppServiceBase
    {
        void Gravar();
        IQueryable Pesquisar();
        void Remover();
        void Atualizar();
        void Alterar();

    }
}
