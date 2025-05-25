using Microsoft.AspNetCore.Mvc;
using ProjetoNet.Models;
using ProjetoNet.Repositories;
using ProjetoNet.Repositories.Interfaces;

namespace ProjetoNet.Controllers
{

    [Route("api/card")]
    [ApiController]
    public class ControllerCard : ControllerBase
    {
        private readonly ICard _CardRepository;

        public ControllerCard(ICard CardRepository)
        {
            _CardRepository = CardRepository;
        }

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
    }
}