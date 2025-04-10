using Microsoft.AspNetCore.Mvc;
using ProjetoNet.Model;
using ProjetoNet.Repositories.Interfaces;
using ProjetoNet.Services;


namespace ProjetoNet.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _UsuarioRepository;
        private readonly TokenServices _tokenServices;

        public UsuariosController(IUsuario UsuarioRepository, TokenServices tokenService)
        {
            _UsuarioRepository = UsuarioRepository;
            _tokenServices = tokenService;
        }

        [HttpPost("criar")]
        public async Task<ActionResult<Usuario>> CriarUsuario([FromBody] Usuario usuario)
        {
            bool emailJaExiste = await _UsuarioRepository.EmailExiste(usuario.email_usuario);
            if (emailJaExiste)
            {
                return Ok(new { mensagem = true });
            }
            await _UsuarioRepository.AdicionarUsuario(usuario);
            return Ok(new 
            { 
                usuario.nome_usuario,
                usuario.email_usuario
            });
        }

      [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] Usuario usuarioLogin)
        {
            var usuario = await _UsuarioRepository.GetUsuarioPorEmail(usuarioLogin.email_usuario);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(usuarioLogin.senha_usuario, usuario.senha_usuario))
            {
                return Unauthorized(new { mensagem = "E-mail ou senha inválidos." });
            }

            var token = _tokenServices.GerarToken(usuario);

            return Ok(new
            {
                token,
                usuario = new
                {
                    usuario.id_usuario,
                    usuario.nome_usuario,
                    usuario.email_usuario
                }
            });
        }

        [HttpGet("teste-api")]
        public IActionResult TesteApi()
        {
            return Ok("API funcionando!");
        }
    }
}
