using CardapioAplicacao.Application.Interface;
using CardapioAplicacao.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CardapioAplicacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        private readonly ICardapioAplicacao _cardapioAplicacao;

        public CardapioController(ICardapioAplicacao cardapioAplicacao)
        {
            _cardapioAplicacao = cardapioAplicacao;            
        }

        [HttpGet]
        public ActionResult<IEnumerable<PizzaViewModel>> SelecionarTodosSabores()
        {
            return Ok(_cardapioAplicacao.SelecionarTodosSabores());
        }

        [HttpGet("{id:int}")]
        public ActionResult<PizzaViewModel> SelecionarSaborPorId(int id)
        {
            var sabor = _cardapioAplicacao.SelecionarSaborPorId(id);

            if (sabor is null)
                return NotFound("Sabor não encontrado");

            return Ok(sabor);
        }

        [HttpPost("adicionarSabor/{id:int}")]
        public ActionResult<PizzaViewModel> AdicionarSabor(int id)
        {
            _cardapioAplicacao.AdicionarSabor(id);
            return Ok("Sabor adicionado");
        }

        [HttpDelete("removerSabor/{id:int}")]
        public ActionResult<PizzaViewModel> RemoverSabor(int id)
        {
            _cardapioAplicacao.RemoverSabor(id);
            return Ok("Sabor removido");
        }

    }
}
