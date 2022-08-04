using AutoMapper;
using CardapioAplicacao.Application.Interface;
using CardapioAplicacao.Application.ViewModel;
using CardapioAplicacao.Domain.Entities;
using CardapioAplicacao.Domain.Repositories;

namespace CardapioAplicacao.Application.App;

public class CardapioApp : ICardapioAplicacao
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private Cardapio _cardapio;

    public CardapioApp(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public void CriarCardapio()
    {
        _cardapio = new();
    }

    public async Task AdicionarSabor(int pizzaId)
    {
        var pizza = await _unitOfWork.PizzaRepositorio.SelecionarPorId(p => p.Id == pizzaId);
        _cardapio.AdicionarPizza(pizza);
    }

    public async Task RemoverSabor(int pizzaId)
    {
        var pizza = await _unitOfWork.PizzaRepositorio.SelecionarPorId(p => p.Id == pizzaId);
        _cardapio.RemoverPizza(pizza);
    }

    public PizzaViewModel SelecionarSaborPorId(int id)
    {
        var pizza = _cardapio.Pizzas.Select(p => p.Id == id);
        return _mapper.Map<PizzaViewModel>(pizza);
    }

    public IEnumerable<PizzaViewModel> SelecionarTodosSabores()
    {
        var pizzas = _cardapio.Pizzas;
        return _mapper.Map<IEnumerable<PizzaViewModel>>(pizzas);
    }
}
