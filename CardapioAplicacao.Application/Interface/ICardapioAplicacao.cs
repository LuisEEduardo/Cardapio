using CardapioAplicacao.Application.ViewModel;

namespace CardapioAplicacao.Application.Interface;

public interface ICardapioAplicacao
{
    void CriarCardapio();
    Task AdicionarSabor(int pizzaId);
    Task RemoverSabor(int pizzaId);
    IEnumerable<PizzaViewModel> SelecionarTodosSabores();
    PizzaViewModel SelecionarSaborPorId(int id);
}
