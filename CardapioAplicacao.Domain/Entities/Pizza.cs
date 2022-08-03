namespace CardapioAplicacao.Domain.Entities;

public class Pizza : Base
{
    public Pizza(string nome, string ingredientes)
    {
        Nome = nome;
        Ingredientes = ingredientes;
        Cardapios = new List<Cardapio>();
    }

    public string Nome { get; private set; }
    public string Ingredientes { get; private set; }

    public IList<Cardapio> Cardapios { get; set; }

    public void AlterarNome(string nome)
    {
        Nome = nome;
    }

    public void AlterarIngredientes(string ingredientes)
    {
        Ingredientes = ingredientes;
    }

}