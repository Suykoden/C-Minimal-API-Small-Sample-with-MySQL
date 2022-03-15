using ProjetoInicial.Data;
using ProjetoInicial.Models.Entidades;
using ProjetoInicial.Respository.RepositoryBase;

namespace ProjetoInicial.Respository.Usuarios
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository() : base(new UsuarioContext())
        {
        }
    }
}
