using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoInicial.Data;
using ProjetoInicial.Factories;
using ProjetoInicial.Models.Entidades;

namespace ProjetoInicial.Controllers
{
    [ApiController]
    [Route("")]
    public class UsuarioController : Controller
    {
        private readonly IFactoryBase<Usuario> _factory;

        public UsuarioController(IFactoryBase<Usuario> factoryBase)
        {
            _factory = factoryBase;
        }

        [HttpGet("teste")]
        public ActionResult Get()
        {
            return Ok();
        }

        //Não é o correto manipulação de persistência dentro das controllers
        //Visto que quebra o padrão de responsabilidade única, refatorar para uso de serviços de acesso a dados.
        [HttpPost("add")]
        public async Task<ActionResult> AdicionarUsuarioAsync([FromBody] Usuario usuario)
        {
            try
            {
                var context = new UsuarioContext();
                var NovoUsuario = _factory.Criar(usuario);
                await context.AddAsync(NovoUsuario);
                await context.SaveChangesAsync();
                return Created($"buscarusuarioporcodigo{NovoUsuario.Codigo}", NovoUsuario);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("listarusuariosasync")]
        public async Task<ActionResult> ListarTodosAsync([FromServices] UsuarioContext context)
          => Ok(await context.Usuario.ToListAsync());

        [HttpGet("buscarusuarioporcodigo/{codigo}")]
        public async Task<ActionResult> BuscarUsuarioPorCodigoAsync(
            [FromServices] UsuarioContext context,
            [FromRoute] string codigo)
         => Ok(await context.Usuario.Where(a => a.Codigo == codigo).ToListAsync());

        [HttpGet("buscarusuarioporid/{id}")]
        public async Task<ActionResult> BuscarUsuarioPorIdAsync(
           [FromServices] UsuarioContext context,
           [FromRoute] Guid id)
        => Ok(await context.Usuario.Where(a => a.Id == id).ToListAsync());

    }
}
