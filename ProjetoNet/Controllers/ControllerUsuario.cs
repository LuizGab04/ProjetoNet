using Microsoft.AspNetCore.Mvc;
using ProjetoNet.Model;
using ProjetoNet.Repositories.Interfaces;


namespace ProjetoNet.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _UsuarioRepository;

        public UsuariosController(IUsuario UsuarioRepository) => _UsuarioRepository = UsuarioRepository;

        [HttpPost]
        public async Task<ActionResult<Usuario>> CriarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                bool emailJaExiste = await _UsuarioRepository.EmailExiste(usuario.email_usuario);
                if (emailJaExiste)
                {
                    return BadRequest(new { mensagem = "email já cadastrado" });
                }

                await _UsuarioRepository.AdicionarUsuario(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult TesteApi()
        {
            return Ok("API funcionando!");
        }
    }
}
