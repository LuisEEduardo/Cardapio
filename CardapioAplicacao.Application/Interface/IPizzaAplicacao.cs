using CardapioAplicacao.Application.ViewModel;
using CardapioAplicacao.Domain.Entities;

namespace CardapioAplicacao.Application.Interface;

public interface IPizzaAplicacao
{
    void AdicionarPizza(PizzaViewModel pizza);
    void AlterarPizza(PizzaViewModel pizza);
    PizzaViewModel SelecionarPorId(int id);
    void Excluir(int id);
    IEnumerable<PizzaViewModel> SelecionarTodas();
}
