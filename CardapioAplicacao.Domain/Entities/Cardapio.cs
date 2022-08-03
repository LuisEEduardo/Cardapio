namespace CardapioAplicacao.Domain.Entities;

public class Cardapio : Base
{
    public Cardapio()
    {
        Pizzas = new List<Pizza>();
    }

    public IList<Pizza> Pizzas { get; private set; }

    public void AdicionarPizza(Pizza pizza)
    {
        Pizzas.Add(pizza);
    }

    public void RemoverPizza(Pizza pizza)
    {
        Pizzas.Remove(pizza);
    }

}
