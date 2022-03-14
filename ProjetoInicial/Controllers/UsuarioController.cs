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

        [HttpPost("add")]
        public ActionResult AdicionarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var context = new UsuarioContext();
                var NovoUsuario = _factory.Criar(usuario);
                context.Add(NovoUsuario);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("listarusuariosasync")]
        public async Task<ActionResult> ListarTodosAsync([FromServices] UsuarioContext context)
          =>  Ok(await context.Usuario.ToListAsync());



    }
}
