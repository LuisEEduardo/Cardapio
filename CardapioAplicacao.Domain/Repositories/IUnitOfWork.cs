namespace CardapioAplicacao.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    ICardapioRepositorio CardapioRepositorio { get; }
    IPizzaRepositorio PizzaRepositorio { get; }
    Task Commit();
}
