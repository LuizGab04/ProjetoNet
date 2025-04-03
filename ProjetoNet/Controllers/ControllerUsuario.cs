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
                if (string.IsNullOrEmpty(usuario.email_usuario))
                {
                    return BadRequest(new { mensagem = "email do usuário é obrigatório" });
                }

                bool emailJaExiste = await _UsuarioRepository.EmailExiste(usuario.email_usuario);
                if (emailJaExiste == true)
                {
                    return BadRequest(new { mensagem = "email já cadastrado" });
                }
                else
                {
                    await _UsuarioRepository.AdicionarUsuario(usuario);
                    return Ok(usuario);
                }
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
