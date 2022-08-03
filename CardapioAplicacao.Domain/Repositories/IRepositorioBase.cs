using System.Linq.Expressions;

namespace CardapioAplicacao.Domain.Repositories;

public interface IRepositorioBase<T> 
{
    void Incluir(T entidade);
    void Alterar(T entidade);
    Task<T> SelecionarPorId(Expression<Func<T, bool>> expression);
    Task ExcluirPorId(Expression<Func<T, bool>> expression);
    IQueryable<T> SelecionarTodos();
}