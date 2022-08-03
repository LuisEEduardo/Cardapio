using CardapioAplicacao.Domain.Entities;
using CardapioAplicacao.Domain.Repositories;

namespace CardapioAplicacao.Data.Repositories;

public class PizzaRepositorio : RepositorioBase<Pizza>, IPizzaRepositorio
{
    public PizzaRepositorio(Contexto contexto)
        : base(contexto)
    {
    }

}
