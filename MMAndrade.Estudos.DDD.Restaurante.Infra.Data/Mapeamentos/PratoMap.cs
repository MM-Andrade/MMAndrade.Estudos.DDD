using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMAndrade.Estudos.DDD.Restaurante.Domain.Entitidades;

namespace MMAndrade.Estudos.DDD.Restaurante.Infra.Data.Mapeamentos
{
    public class PratoMap : MapBase<Prato>
    {
        public override void Configure(EntityTypeBuilder<Prato> builder)
        {
            base.Configure(builder);
            builder.ToTable("TBL_PRATO");
            builder.Property(c => c.Nome).IsRequired().HasColumnName("NOME").HasMaxLength(100);
            builder.Property(c => c.Preco).IsRequired().HasColumnName("PRECO");
        }
    }
}
