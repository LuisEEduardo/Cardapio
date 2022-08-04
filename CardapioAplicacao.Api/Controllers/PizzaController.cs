using CardapioAplicacao.Application.Interface;
using CardapioAplicacao.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CardapioAplicacao.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly IPizzaAplicacao _pizzaAplicacao;

    public PizzaController(IPizzaAplicacao pizzaAplicacao)
    {
        _pizzaAplicacao = pizzaAplicacao;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PizzaViewModel>> SelecionarTodas()
    {
        return Ok(_pizzaAplicacao.SelecionarTodas());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PizzaViewModel>> SelecionarPorId(int id)
    {
        var pizza = await _pizzaAplicacao.SelecionarPorId(id);

        if (pizza is null)
            return NotFound("Pizza não encontrada");

        return Ok(pizza);
    }

    [HttpPost]
    public async Task<ActionResult<PizzaViewModel>> Incluir([FromBody] PizzaViewModel pizza)
    {
        if (pizza is null)
            return BadRequest();

        await _pizzaAplicacao.AdicionarPizza(pizza);
        return Ok(pizza);
    }

    [HttpPut]
    public async Task<ActionResult<PizzaViewModel>> Alterar([FromBody] PizzaViewModel pizza)
    {
        if (pizza is null)
            return BadRequest();

        await _pizzaAplicacao.AlterarPizza(pizza);
        return Ok(pizza);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<PizzaViewModel>> Excluir(int id)
    {
        await _pizzaAplicacao.Excluir(id);
        return Ok(id);
    }

}
