using CardapioAplicacao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CardapioAplicacao.Data.Repositories
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        private readonly Contexto _context;

        public RepositorioBase(Contexto context)
        {
            _context = context;
        }

        public void Incluir(T entidade)
        {
            _context.Set<T>().Add(entidade);
        }

        public void Alterar(T entidade)
        {
            _context.Set<T>().Update(entidade);
        }

        public async Task<T> SelecionarPorId(Expression<Func<T, bool>> expression)
            => await _context.Set<T>().FirstOrDefaultAsync(expression);

        public async Task ExcluirPorId(Expression<Func<T, bool>> expression)
        {
            var entidade = await SelecionarPorId(expression);
            _context.Set<T>().Remove(entidade);
        }

        public IQueryable<T> SelecionarTodos()
            => _context.Set<T>().AsTracking();
       
    }
}
