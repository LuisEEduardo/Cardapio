using CardapioAplicacao.Domain.Repositories;

namespace CardapioAplicacao.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private CardapioRepositorio _cardapioRepositorio;
    private IPizzaRepositorio _pizzaRepositorio;
    private Contexto _context;

    public UnitOfWork(Contexto context)
    {
        _context = context;
    }

    public ICardapioRepositorio CardapioRepositorio => _cardapioRepositorio ?? new CardapioRepositorio(_context);

    public IPizzaRepositorio PizzaRepositorio => _pizzaRepositorio ?? new PizzaRepositorio(_context);

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
