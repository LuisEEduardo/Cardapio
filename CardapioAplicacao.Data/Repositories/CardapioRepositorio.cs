using CardapioAplicacao.Domain.Entities;
using CardapioAplicacao.Domain.Repositories;

namespace CardapioAplicacao.Data.Repositories;

public class CardapioRepositorio : RepositorioBase<Cardapio>, ICardapioRepositorio
{
    public CardapioRepositorio(Contexto contexto)
        : base(contexto)
    {
    }    
}
