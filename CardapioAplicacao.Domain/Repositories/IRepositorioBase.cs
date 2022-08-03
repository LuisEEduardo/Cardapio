namespace CardapioAplicacao.Domain.Repositories;

public interface IRepositorioBase<T> : IDisposable where T : class
{
    void Incluir(T entidade);
    void Alterar(T entidade);
    Task<T> SelecionarPorId(int id);
    void Excluir(int id);
    IQueryable<T> SelecionarTodos();
}