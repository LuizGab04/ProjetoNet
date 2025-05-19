using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ProjetoNet.Models;
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

        [HttpPost]
        public async Task<> AdicionarCard([FromBody] Card card)
        {
            try
            {
                return Ok(await _CardRepository.CriarCard(card));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao criar a sprint", erro = ex.Message });
            }
        }

    }
}