using Microsoft.AspNetCore.Mvc;
using ProjetoNet.Models;
using ProjetoNet.Repositories.Interfaces;

namespace ProjetoNet.Controllers
{

    [Route("api/card")]
    [ApiController]
    public class ControllerCard(ICard CardRepository) : ControllerBase
    {
        private readonly ICard _CardRepository = CardRepository ?? throw new ArgumentNullException(nameof(CardRepository));

        [HttpPost("criarCard")]
        public async Task<ActionResult<int>> AdicionarCard([FromBody] Card card)
        {
            try
            {
                return Ok(await _CardRepository.AdicionarCards(card));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar o card", erro = ex.Message });
            }
        }
        [HttpPost("atualizarCard")]
        public async Task<ActionResult> AtualizarCard([FromBody] Card card)
        {
            try
            {
                await _CardRepository.AtualizarCard(card);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao atualizar o card", erro = ex.Message });
            }
        }


        [HttpGet("{id_sprint}")]
        public async Task<ActionResult> MostrarCards(int id_sprint)
        {
            try
            {
                return Ok(await _CardRepository.MostrarCards(id_sprint));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao mostrar o card", erro = ex.Message });
            }
        }
    }
}