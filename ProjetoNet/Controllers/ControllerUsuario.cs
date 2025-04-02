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
            if (usuario == null)
            {
                return BadRequest("Usuário inválido.");
            }
            if(await _UsuarioRepository.EmailExiste(usuario.email_usuario)){
                return BadRequest(new { mensagem = "email já cadastrado"});
            }

            try
            {
                Console.WriteLine($"Recebido: {usuario.nome_usuario}, {usuario.email_usuario}, {usuario.senha_usuario}");

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
