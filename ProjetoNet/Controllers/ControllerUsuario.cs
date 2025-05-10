using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoNet.Model;
using ProjetoNet.Repositories;
using ProjetoNet.Repositories.Interfaces;
using ProjetoNet.Services;
using System.Security.Claims;


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
        public async Task<ActionResult<Usuario>> Login([FromBody] Usuario usuario)
        {
            var usuarioLogin = await _UsuarioRepository.GetUsuarioPorEmail(usuario.email_usuario);

            if (usuarioLogin == null || !BCrypt.Net.BCrypt.Verify(usuario.senha_usuario, usuarioLogin.senha_usuario))
            {
                return Ok(new { mensagem = "Cadastro incorreto" });
            }

            var token = _tokenServices.GerarToken(usuarioLogin);

            return Ok(new
            {
                token,
                usuario = new
                {
                    usuarioLogin.id_usuario,
                    usuarioLogin.nome_usuario,
                    usuarioLogin.email_usuario,
                    usuarioLogin.foto_perfil
                }
            });
        }

        [HttpPost("foto")]
        public async Task<IActionResult> UploadFoto( IFormFile foto)
        {
            if (foto == null || foto.Length == 0)
            {
                return BadRequest(new { mensagem = "Nenhuma foto foi enviada." });
            }

            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            
            using var memoryStream = new MemoryStream();
            await foto.CopyToAsync(memoryStream);
            var fotoBytes = memoryStream.ToArray();

            await _UsuarioRepository.SalvarFotoPerfilAsync(email, fotoBytes);

            return Ok(new { fotoBytes });
        }

        [HttpGet("fotoPerfil")]
        public async Task<IActionResult> GetFotoPerfil()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email)) return Unauthorized();

            var fotoBytes = await _UsuarioRepository.ObterFotoPerfilAsync(email);
            if (fotoBytes == null || fotoBytes.Length == 0)
            {

                return Ok(new { mensagem = "usuario não tem imagem" });
            }else
            {
                return Ok(new { fotoBytes });
            }
        }

        [HttpGet("teste-api")]
        public IActionResult TesteApi()
        {
            return Ok("API funcionando!");
        }
    }
}
