using Microsoft.AspNetCore.Mvc;
using ProjetoNet.Models;
using ProjetoNet.Repositories.Interfaces;


namespace ProjetoNet.Controllers
{
    [Route("api/sprint")]
    [ApiController]
    public class ControllerSprint : ControllerBase
    {
        private readonly ISprint _sprintRepository;

       public ControllerSprint(ISprint sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        [HttpPost("criar")]
        public async Task<ActionResult<int>> CriarSprint([FromBody] Sprint sprint)
        {
            try
            {
                return Ok(await _sprintRepository.AdicionarSprint(sprint));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao criar a sprint", erro = ex.Message });
            }
        }

        [HttpGet("mostrarSprints")]
        public async Task<ActionResult> ListaSprints()
        {
            try
            {
                return Ok(await _sprintRepository.MostrarSprints());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao mostrar a sprint", erro = ex.Message });

            }
        }

        [HttpDelete("{id_sprint}")]
        public async Task<ActionResult> ExcluirSprint(int id_sprint)
        {
            try
            {
                return Ok(await _sprintRepository.ExcluirSprint(id_sprint));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao mostrar a sprint", erro = ex.Message });
            }
        }
    }
}
