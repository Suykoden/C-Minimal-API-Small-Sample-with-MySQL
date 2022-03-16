using ProjetoInicial.Factories;
using ProjetoInicial.Models.Entidades;
using ProjetoInicial.Repository;
using ProjetoInicial.Servicos.ServicosBase;

namespace ProjetoInicial.Servicos.UsuarioServices
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        public UsuarioAppService(IRepository<Usuario> repository, IFactoryBase<Usuario> factory) : base(repository, factory)
        {
        }
    }
}
