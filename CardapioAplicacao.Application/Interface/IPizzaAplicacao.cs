using CardapioAplicacao.Application.ViewModel;

namespace CardapioAplicacao.Application.Interface;

public interface IPizzaAplicacao
{
    Task AdicionarPizza(PizzaViewModel pizza);
    Task AlterarPizza(PizzaViewModel pizza);
    Task<PizzaViewModel> SelecionarPorId(int id);
    Task Excluir(int id);
    IEnumerable<PizzaViewModel> SelecionarTodas();
}
