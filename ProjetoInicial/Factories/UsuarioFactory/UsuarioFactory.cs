using ProjetoInicial.LibGenerica;
using ProjetoInicial.Models.Entidades;

namespace ProjetoInicial.Factories
{
    public class UsuarioFactory : IFactoryBase<Usuario>
    {
        private readonly ILibGenerica _libGenerica;
        public UsuarioFactory(ILibGenerica libGenerica)
        {
            _libGenerica = libGenerica;
        }
        public Usuario Criar(Usuario usuario)
        {
            return new Usuario
            {
                Id = Guid.NewGuid(),
                Codigo = _libGenerica.GeraCodigo(),
                Nome = usuario.Nome,
                Ativo = true,
                Idade = usuario.Idade
            };
        }
    }
}
