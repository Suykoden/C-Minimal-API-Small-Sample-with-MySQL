namespace ProjetoInicial.Factories
{
    public interface IFactoryBase<Entidade>
    {
        Entidade Criar(Entidade T);
    }
}
