using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MK.QRMenu.Domain.Entities;

namespace MK.QRMenu.Infrastructure.Configurations
{
    internal sealed class KategoriConfiguration : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(x => x.KategoriAdi).HasColumnType("varchar(100)");
            builder.Property(x => x.ArkaPlanRengi).HasColumnType("varchar(50)");
            builder.Property(x => x.YaziRengi).HasColumnType("varchar(50)");
        }
    }
}
