using AutoMapper;
using CardapioAplicacao.Application.Interface;
using CardapioAplicacao.Application.ViewModel;
using CardapioAplicacao.Domain.Entities;

namespace CardapioAplicacao.Application.App;

public class CardapioAplicacao : ICardapioAplicacao
{
    private readonly IMapper _mapper;
    private Cardapio _cardapio;

    public CardapioAplicacao(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AdicionarSabor(PizzaViewModel pizza)
    {
        _cardapio.AdicionarPizza(_mapper.Map<Pizza>(pizza));
    }

    public void CriarCardapio()
    {
        _cardapio = new();
    }

    public void RemoverSabor(PizzaViewModel pizza)
    {
        _cardapio.RemoverPizza(_mapper.Map<Pizza>(pizza));
    }
}
