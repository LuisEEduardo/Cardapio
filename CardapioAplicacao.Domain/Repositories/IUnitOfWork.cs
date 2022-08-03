namespace CardapioAplicacao.Domain.Repositories;

public interface IUnitOfWork
{
    ICardapioRepositorio CardapioRepositorio { get; }
    IPizzaRepositorio PizzaRepositorio { get; }
    Task Commit();
}
