using Microsoft.AspNetCore.Mvc;
using ProjetoNet.Model;
using ProjetoNet.Repositories;
using ProjetoNet.Repositories.Interfaces;
using ZstdSharp.Unsafe;

namespace ProjetoNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerUsuario : ControllerBase
    {
        private readonly IUsuario _UsuarioRepository;

        public ControllerUsuario(IUsuario UsuarioRepository) => _UsuarioRepository = UsuarioRepository;
        
        [HttpPost]
        public async Task<ActionResult<Usuario>> Create(Usuario usuario)
        {
            try
            {
                await _UsuarioRepository.AdicionarUsuario(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

    }
}
