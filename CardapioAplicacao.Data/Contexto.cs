using CardapioAplicacao.Data.Map;
using CardapioAplicacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardapioAplicacao.Data;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }

    public DbSet<Cardapio> Cardapios { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PizzaMap());
        modelBuilder.ApplyConfiguration(new CardapioMap());

        base.OnModelCreating(modelBuilder);
    }


}
