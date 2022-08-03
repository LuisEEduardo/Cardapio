using CardapioAplicacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardapioAplicacao.Data.Map;

public class PizzaMap : IEntityTypeConfiguration<Pizza>
{
    public void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.ToTable("Pizza");

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(p => p.Nome)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(p => p.Ingredientes)
            .HasColumnType("varchar(200)")
            .IsRequired();
    }
}
