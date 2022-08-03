using CardapioAplicacao.Application.ViewModel;

namespace CardapioAplicacao.Application.Interface;

public interface ICardapioAplicacao
{
    void CriarCardapio();
    void AdicionarSabor(PizzaViewModel pizza);
    void RemoverSabor(PizzaViewModel pizza);
}
