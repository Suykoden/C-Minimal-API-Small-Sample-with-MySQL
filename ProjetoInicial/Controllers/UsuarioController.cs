using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoInicial.Data;
using ProjetoInicial.Factories;
using ProjetoInicial.Models.Entidades;
using ProjetoInicial.Servicos.UsuarioServices;

namespace ProjetoInicial.Controllers
{
    [ApiController]
    [Route("")]
    public class UsuarioController : Controller
    {
        // private readonly IFactoryBase<Usuario> _factory;
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            //  _factory = factoryBase;
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet("teste")]
        public ActionResult Get()
        {
            return Ok();
        }

        [HttpPost("add")]
        public async Task<ActionResult> AdicionarUsuarioAsync([FromBody] Usuario usuario)
        {
            try
            {
                var NovoUsuario = await _usuarioAppService.NovoAsync(usuario);
                return Created($"buscarusuarioporcodigo{NovoUsuario.Codigo}", NovoUsuario);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("listarusuariosasync")]
        public async Task<ActionResult> ListarTodosAsync([FromServices] Context context)
        {
            try
            {
                var teste = await context.Usuario.ToListAsync();
                return Ok(teste);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("buscarusuarioporcodigo/{codigo}")]
        public async Task<ActionResult> BuscarUsuarioPorCodigoAsync(
        [FromServices] Context context, [FromRoute] string codigo)
          => Ok(await context.Usuario.Where(a => a.Codigo == codigo).ToListAsync());

        [HttpGet("buscarusuarioporid/{id}")]
        public async Task<ActionResult> BuscarUsuarioPorIdAsync([FromServices] Context context,  [FromRoute] Guid id)
          => Ok(await context.Usuario.Where(a => a.Id == id).ToListAsync());

        [HttpGet("Novobuscarusuarioporid/{id}")]
        public async Task<ActionResult> NovoBuscarUsuarioPorIdAsync([FromServices] Context context, [FromRoute] Guid id)
            => Ok(await context.Usuario.Where(a => a.Id == id).ToListAsync());


    }
}
