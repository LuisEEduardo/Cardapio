using CardapioAplicacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardapioAplicacao.Data.Map;

public class CardapioMap : IEntityTypeConfiguration<Cardapio>
{
    public void Configure(EntityTypeBuilder<Cardapio> builder)
    {
        builder.ToTable("Cardapio");

        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .HasMany(c => c.Pizzas)
            .WithMany(p => p.Cardapios);
    }
}
